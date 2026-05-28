using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NhaMeoShop.Models;

namespace NhaMeoShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // DASHBOARD
        // =========================
        public IActionResult Index()
        {
            ViewBag.TongSanPham =
                _context.SanPhams.Count();

            ViewBag.TongLoaiSP =
                _context.LoaiSanPhams.Count();

            ViewBag.TongNhanVien =
                _context.NhanViens.Count();

            ViewBag.TongKhachHang =
                _context.KhachHangs.Count();

            ViewBag.TongHoaDon =
                _context.HoaDons.Count();

            ViewBag.DoanhThu =
                _context.ChiTietHoaDons
                .Sum(x => x.SLBan * x.DGBan);

            return View();
        }
    }
}