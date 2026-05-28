using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NhaMeoShop.Models;

namespace NhaMeoShop.Controllers
{
    [Authorize]
    public class HoaDonController : Controller
    {
        private readonly AppDbContext _context;

        private readonly UserManager<IdentityUser>
            _userManager;

        public HoaDonController(
            AppDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;

            _userManager = userManager;
        }

        // =========================================
        // DANH SÁCH HÓA ĐƠN
        // =========================================
        public async Task<IActionResult> Index()
        {
            var dsHoaDon = await _context.HoaDons
                .Include(x => x.KhachHang)
                .Include(x => x.ChiTietHoaDons)
                .OrderByDescending(x => x.NgayLap)
                .ToListAsync();

            return View(dsHoaDon);
        }

        // =========================================
        // CHI TIẾT HÓA ĐƠN
        // =========================================
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(x => x.KhachHang)
                .Include(x => x.ChiTietHoaDons)
                .ThenInclude(x => x.SanPham)
                .FirstOrDefaultAsync(m => m.SoHD == id);

            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // =========================================
        // THANH TOÁN GIỎ HÀNG
        // =========================================
        [HttpPost]
        public async Task<IActionResult> ThanhToan()
        {
            try
            {
                // LẤY USER ĐANG LOGIN
                var user =
                    await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToPage(
                        "/Account/Login",
                        new { area = "Identity" });
                }

                // LẤY KHÁCH HÀNG
                var kh = await _context.KhachHangs
                    .FirstOrDefaultAsync(
                        x => x.UserId == user.Id);

                if (kh == null)
                {
                    return Content(
                        "Không tìm thấy khách hàng");
                }

                // LẤY GIỎ HÀNG
                var cartJson =
                    HttpContext.Session.GetString("cart");

                if (string.IsNullOrEmpty(cartJson))
                {
                    TempData["msg"] =
                        "Giỏ hàng đang trống!";

                    return RedirectToAction(
                        "Index",
                        "Cart");
                }

                // JSON -> LIST
                List<CartItem> cart =
                    JsonConvert.DeserializeObject
                    <List<CartItem>>(cartJson);

                // TẠO MÃ HÓA ĐƠN
                string soHD =
                    "HD" +
                    DateTime.Now
                    .ToString("yyyyMMddHHmmss");

                // TẠO HÓA ĐƠN
                HoaDon hoaDon = new HoaDon
                {
                    SoHD = soHD,

                    NgayLap = DateTime.Now,

                    PhuPhi = 0,

                    KhuyenMai = 0,

                    HinhThuc = true,

                    HinhThucTT = true,

                    TrangThai = false,

                    GhiChuHD = "Đơn hàng online",

                    // GÁN KHÁCH HÀNG
                    MaKH = kh.MaKH,

                    MaNV = null
                };

                // ADD HÓA ĐƠN
                _context.HoaDons.Add(hoaDon);

                // ADD CHI TIẾT HÓA ĐƠN
                foreach (var item in cart)
                {
                    ChiTietHoaDon ct =
                        new ChiTietHoaDon
                        {
                            SoHD = soHD,

                            MaSP =
                                item.SanPham.MaSP,

                            SLBan =
                                item.SoLuong,

                            DGBan =
                                item.SanPham.DonGiaSP,

                            GhiChuHoaDon = ""
                        };

                    _context.ChiTietHoaDons.Add(ct);
                }

                // SAVE
                await _context.SaveChangesAsync();

                // XÓA GIỎ HÀNG
                HttpContext.Session.Remove("cart");

                TempData["msg"] =
                    "Đặt hàng thành công!";

                return RedirectToAction(
                    nameof(Details),
                    new { id = soHD });
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // =========================================
        // CREATE
        // =========================================
        public IActionResult Create()
        {
            return View();
        }

        // =========================================
        // CREATE POST
        // =========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("SoHD,NgayLap,PhuPhi,KhuyenMai,HinhThuc,HinhThucTT,TrangThai,GhiChuHD,MaKH,MaNV")]
            HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);

                await _context.SaveChangesAsync();

                TempData["msg"] =
                    "Thêm hóa đơn thành công";

                return RedirectToAction(nameof(Index));
            }

            return View(hoaDon);
        }

        // =========================================
        // EDIT
        // =========================================
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon =
                await _context.HoaDons.FindAsync(id);

            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // =========================================
        // EDIT POST
        // =========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            string id,
            [Bind("SoHD,NgayLap,PhuPhi,KhuyenMai,HinhThuc,HinhThucTT,TrangThai,GhiChuHD,MaKH,MaNV")]
            HoaDon hoaDon)
        {
            if (id != hoaDon.SoHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);

                    await _context.SaveChangesAsync();

                    TempData["msg"] =
                        "Cập nhật hóa đơn thành công";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.SoHD))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(hoaDon);
        }

        // =========================================
        // DELETE
        // =========================================
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .FirstOrDefaultAsync(
                    m => m.SoHD == id);

            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // =========================================
        // DELETE POST
        // =========================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            DeleteConfirmed(string id)
        {
            var hoaDon =
                await _context.HoaDons.FindAsync(id);

            if (hoaDon != null)
            {
                var chiTietHD =
                    await _context.ChiTietHoaDons
                    .Where(x => x.SoHD == id)
                    .ToListAsync();

                _context.ChiTietHoaDons
                    .RemoveRange(chiTietHD);

                _context.HoaDons.Remove(hoaDon);

                await _context.SaveChangesAsync();

                TempData["msg"] =
                    "Đã xóa hóa đơn";
            }

            return RedirectToAction(nameof(Index));
        }

        // =========================================
        // CHECK
        // =========================================
        private bool HoaDonExists(string id)
        {
            return _context.HoaDons
                .Any(e => e.SoHD == id);
        }
    }
}