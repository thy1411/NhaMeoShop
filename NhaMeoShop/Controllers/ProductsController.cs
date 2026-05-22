using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NhaMeoShop.Models;

namespace NhaMeoShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _environment;

        public ProductsController(
            AppDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var appDbContext =
                _context.SanPhams
                .Include(s => s.LoaiSanPham);

            return View(await appDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.MaSP == id);

            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["MaLoaiSP"] =
                new SelectList(
                    _context.LoaiSanPhams,
                    "MaLoaiSP",
                    "TenLoaiSP");

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            SanPham sanPham,
            IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                // Upload hình
                if (imageFile != null)
                {
                    string fileName =
                        Path.GetFileName(imageFile.FileName);

                    string path =
                        Path.Combine(
                            _environment.WebRootPath,
                            "images",
                            fileName);

                    using (var stream =
                        new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    sanPham.HinhAnhSP = fileName;
                }

                _context.Add(sanPham);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["MaLoaiSP"] =
                new SelectList(
                    _context.LoaiSanPhams,
                    "MaLoaiSP",
                    "TenLoaiSP",
                    sanPham.MaLoaiSP);

            return View(sanPham);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham =
                await _context.SanPhams.FindAsync(id);

            if (sanPham == null)
            {
                return NotFound();
            }

            ViewData["MaLoaiSP"] =
                new SelectList(
                    _context.LoaiSanPhams,
                    "MaLoaiSP",
                    "TenLoaiSP",
                    sanPham.MaLoaiSP);

            return View(sanPham);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            string id,
            SanPham sanPham,
            IFormFile imageFile)
        {
            if (id != sanPham.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldProduct =
                        await _context.SanPhams
                        .AsNoTracking()
                        .FirstOrDefaultAsync(
                            x => x.MaSP == id);

                    // Upload hình mới
                    if (imageFile != null)
                    {
                        string fileName =
                            Path.GetFileName(
                                imageFile.FileName);

                        string path =
                            Path.Combine(
                                _environment.WebRootPath,
                                "images",
                                fileName);

                        using (var stream =
                            new FileStream(
                                path,
                                FileMode.Create))
                        {
                            await imageFile
                                .CopyToAsync(stream);
                        }

                        sanPham.HinhAnhSP = fileName;
                    }
                    else
                    {
                        sanPham.HinhAnhSP =
                            oldProduct.HinhAnhSP;
                    }

                    _context.Update(sanPham);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.MaSP))
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

            ViewData["MaLoaiSP"] =
                new SelectList(
                    _context.LoaiSanPhams,
                    "MaLoaiSP",
                    "TenLoaiSP",
                    sanPham.MaLoaiSP);

            return View(sanPham);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.MaSP == id);

            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(
            string id)
        {
            var sanPham =
                await _context.SanPhams.FindAsync(id);

            // Xóa hình
            if (!string.IsNullOrEmpty(
                sanPham.HinhAnhSP))
            {
                string imagePath =
                    Path.Combine(
                        _environment.WebRootPath,
                        "images",
                        sanPham.HinhAnhSP);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.SanPhams.Remove(sanPham);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(string id)
        {
            return _context.SanPhams
                .Any(e => e.MaSP == id);
        }
    }
}