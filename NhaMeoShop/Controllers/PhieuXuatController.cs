using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NhaMeoShop.Models;

namespace NhaMeoShop.Controllers
{
    public class PhieuXuatController : Controller
    {
        private readonly AppDbContext _context;

        public PhieuXuatController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PhieuXuat
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhieuXuats.ToListAsync());
        }

        // GET: PhieuXuat/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var phieuXuat = await _context.PhieuXuats
                .FirstOrDefaultAsync(x => x.SoPX == id);

            if (phieuXuat == null)
                return NotFound();

            ViewBag.CTPX = await _context.ChiTietPhieuXuats
                .Include(x => x.KhoTong)
                .Include(x => x.KhoPhaChe)
                .Where(x => x.SoPX == id)
                .ToListAsync();

            return View(phieuXuat);
        }

        // GET: PhieuXuat/Create
        public IActionResult Create()
        {
            string soPX = "PX0001";

            var last = _context.PhieuXuats
                .OrderByDescending(x => x.SoPX)
                .FirstOrDefault();

            if (last != null)
            {
                int stt = int.Parse(last.SoPX.Substring(2));
                soPX = "PX" + (stt + 1).ToString("D4");
            }

            ViewBag.SoPX = soPX;

            ViewBag.NL = _context.KhoTongs.ToList();
            ViewBag.NhanVienQK = _context.NhanViens
        .Where(x => x.MaLoaiNV == "QK")
        .ToList();

            return View(new PhieuXuat
            {
                SoPX = soPX,
                NgayXuat = DateTime.Now
            });
        }

        // POST: PhieuXuat/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
    PhieuXuat phieuXuat,
    string[] MaNL,
    int[] SoLuong)
        {
            if (ModelState.IsValid)
            {
                // Sinh số phiếu xuất tự động
                string soPX = "PX0001";

                var last = await _context.PhieuXuats
                    .OrderByDescending(x => x.SoPX)
                    .FirstOrDefaultAsync();

                if (last != null)
                {
                    int stt = int.Parse(last.SoPX.Substring(2));
                    soPX = "PX" + (stt + 1).ToString("D4");
                }

                phieuXuat.SoPX = soPX;

                _context.PhieuXuats.Add(phieuXuat);

                for (int i = 0; i < MaNL.Length; i++)
                {
                    var khoTong = await _context.KhoTongs
                        .FirstOrDefaultAsync(x => x.MaNL == MaNL[i]);

                    if (khoTong == null)
                        continue;

                    if (khoTong.SoLuongTon < SoLuong[i])
                    {
                        ModelState.AddModelError("",
                            $"Nguyên liệu {khoTong.TenNL} không đủ tồn kho");

                        ViewBag.NL = _context.KhoTongs.ToList();
                        ViewBag.SoPX = soPX;
                        ViewBag.NL = _context.KhoTongs.ToList();

                        ViewBag.NhanVienQK = _context.NhanViens
                            .Where(x => x.MaLoaiNV == "QK")
                            .ToList();
                        return View(phieuXuat);
                    }

                    // Trừ kho tổng
                    khoTong.SoLuongTon -= SoLuong[i];


                    var ct = new ChiTietPhieuXuat
                    {
                        SoPX = soPX,
                        MaNL = MaNL[i],
                        SLXuat = SoLuong[i]
                    };

                    _context.ChiTietPhieuXuats.Add(ct);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.NL = _context.KhoTongs.ToList();
            ViewBag.NhanVienQK = _context.NhanViens
    .Where(x => x.MaLoaiNV == "QK")
    .ToList();

            return View(phieuXuat);
        }

        // GET: PhieuXuat/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuXuat = await _context.PhieuXuats.FindAsync(id);
            if (phieuXuat == null)
            {
                return NotFound();
            }
            return View(phieuXuat);
        }

        // POST: PhieuXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SoPX,NgayXuat,XuatHang,GhiChuPX")] PhieuXuat phieuXuat)
        {
            if (id != phieuXuat.SoPX)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuXuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuXuatExists(phieuXuat.SoPX))
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
            return View(phieuXuat);
        }

        // GET: PhieuXuat/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuXuat = await _context.PhieuXuats
                .FirstOrDefaultAsync(m => m.SoPX == id);
            if (phieuXuat == null)
            {
                return NotFound();
            }

            return View(phieuXuat);
        }

        // POST: PhieuXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phieuXuat = await _context.PhieuXuats.FindAsync(id);
            _context.PhieuXuats.Remove(phieuXuat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuXuatExists(string id)
        {
            return _context.PhieuXuats.Any(e => e.SoPX == id);
        }
    }
}
