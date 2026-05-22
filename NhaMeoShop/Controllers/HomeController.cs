using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NhaMeoShop.Models;
using System.Linq;

namespace NhaMeoShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sanPham = _context.SanPhams
                .Include(x => x.LoaiSanPham)
                .ToList();

            return View(sanPham);
        }
    }
}