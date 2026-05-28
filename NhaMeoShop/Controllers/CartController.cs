using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NhaMeoShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace NhaMeoShop.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // HIỂN THỊ GIỎ HÀNG
        // =========================
        public IActionResult Index()
        {
            var cart = GetCart();

            return View(cart);
        }

        // =========================
        // THÊM VÀO GIỎ
        // =========================

        public IActionResult AddToCart(string id)
        {
            var sp = _context.SanPhams
                .FirstOrDefault(x => x.MaSP == id);

            if (sp == null)
            {
                return NotFound();
            }

            var cart = GetCart();

            var item = cart
                .FirstOrDefault(x =>
                    x.SanPham.MaSP == id);

            if (item != null)
            {
                item.SoLuong++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    SanPham = sp,
                    SoLuong = 1
                });
            }

            SaveCart(cart);

            TempData["msg"] =
                "Đã thêm vào giỏ hàng 🛒";

            // QUAY LẠI TRANG CŨ
            return Redirect(
                Request.Headers["Referer"].ToString());
        }

        // =========================
        // XÓA KHỎI GIỎ
        // =========================
        public IActionResult Remove(string id)
        {
            var cart = GetCart();

            var item = cart
                .FirstOrDefault(x =>
                    x.SanPham.MaSP == id);

            if (item != null)
            {
                cart.Remove(item);
            }

            SaveCart(cart);

            TempData["msg"] =
                "Đã xóa sản phẩm ❌";

            return RedirectToAction("Index");
        }

        // =========================
        // THANH TOÁN
        // =========================
        public IActionResult Checkout()
        {
            var cart = GetCart();

            if (cart.Count == 0)
            {
                TempData["msg"] =
                    "Giỏ hàng đang trống";

                return RedirectToAction(
                    "Index");
            }

            // XÓA GIỎ HÀNG
            HttpContext.Session.Remove("CART");

            TempData["msg"] =
                "Thanh toán thành công";

            return RedirectToAction(
                "Index");
        }

        // =========================
        // LẤY GIỎ HÀNG
        // =========================
        private List<CartItem> GetCart()
        {
            var session =
                HttpContext.Session
                .GetString("CART");

            if (session != null)
            {
                return JsonConvert
                    .DeserializeObject
                    <List<CartItem>>(session);
            }

            return new List<CartItem>();
        }

        // =========================
        // LƯU GIỎ HÀNG
        // =========================
        private void SaveCart(
            List<CartItem> cart)
        {
            HttpContext.Session
                .SetString(
                    "CART",
                    JsonConvert.SerializeObject(cart));
        }
    }
}