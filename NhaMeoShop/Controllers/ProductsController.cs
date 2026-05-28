using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public ProductsController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // =========================
        // DANH SÁCH SẢN PHẨM
        // =========================
        public async Task<IActionResult> Index(string maloai, int page = 1)
        {
            int pageSize = 6;

            var ds = _context.SanPhams.Include(x => x.LoaiSanPham).AsQueryable();

            // LỌC THEO LOẠI
            if (!string.IsNullOrEmpty(maloai))
            {
                ds = ds.Where(x => x.MaLoaiSP == maloai);

                var loai = await _context.LoaiSanPhams.FirstOrDefaultAsync(x => x.MaLoaiSP == maloai);

                if (loai != null)
                {
                    ViewBag.TenLoai = loai.TenLoaiSP;
                }
            }else
            {
                ViewBag.TenLoai = "Tất cả sản phẩm";
            }

            // TỔNG SẢN PHẨM
            int totalProducts = await ds.CountAsync();

            // TỔNG TRANG
            int totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.MaLoai = maloai;

            // PHÂN TRANG
            var products = await ds.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return View(products);
        }

        // =========================
        // CHI TIẾT
        // =========================
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.Include(s => s.LoaiSanPham).FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // =========================
        // CREATE
        // =========================
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Create()
        {
            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP");
            return View();
        }

        // =========================
        // CREATE POST
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Create(SanPham sanPham, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                // UPLOAD HÌNH
                if (imageFile != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string path = Path.Combine(_environment.WebRootPath, "images", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    sanPham.HinhAnhSP = fileName;
                }
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                TempData["msg"] = "Thêm sản phẩm thành công";
                return RedirectToAction(nameof(Index));
            }

            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);

            return View(sanPham);
        }

        // =========================
        // EDIT
        // =========================
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            return View(sanPham);
        }

        // =========================
        // EDIT POST
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Edit(string id, SanPham sanPham, IFormFile imageFile)
        {
            if (id != sanPham.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldProduct = await _context.SanPhams.AsNoTracking().FirstOrDefaultAsync(x => x.MaSP == id);
                    // UPLOAD HÌNH MỚI
                    if (imageFile != null)
                    {
                        // XÓA HÌNH CŨ
                        if (!string.IsNullOrEmpty(
                            oldProduct.HinhAnhSP))
                        {
                            string oldImage = Path.Combine(_environment.WebRootPath, "images", oldProduct.HinhAnhSP);
                            if (System.IO.File.Exists(oldImage))
                            {
                                System.IO.File.Delete(oldImage);
                            }
                        }
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                        string path = Path.Combine(_environment.WebRootPath, "images", fileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }

                        sanPham.HinhAnhSP = fileName;
                    }
                    else
                    {
                        sanPham.HinhAnhSP = oldProduct.HinhAnhSP;
                    }
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                    TempData["msg"] = "Cập nhật sản phẩm thành công ✨";
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

            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            return View(sanPham);
        }

        // =========================
        // DELETE
        // =========================
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.Include(s => s.LoaiSanPham).FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // =========================
        // DELETE POST
        // =========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>
            DeleteConfirmed(string id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);

            // XÓA HÌNH
            if (!string.IsNullOrEmpty(sanPham.HinhAnhSP))
            {
                string imagePath = Path.Combine(_environment.WebRootPath, "images", sanPham.HinhAnhSP);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }_context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            TempData["msg"] = "Đã xóa sản phẩm ️";

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // CHECK
        // =========================
        private bool SanPhamExists(string id)
        {
            return _context.SanPhams.Any(e => e.MaSP == id);
        }
    }
}