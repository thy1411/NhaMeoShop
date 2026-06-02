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
    public class PhieuNhapController : Controller
    {
        private readonly AppDbContext _context;

        public PhieuNhapController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PhieuNhap
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhieuNhaps.ToListAsync());
        }

        // GET: PhieuNhap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuNhap = await _context.PhieuNhaps
                .FirstOrDefaultAsync(x => x.SoPN == id);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            ViewBag.ChiTiet = await _context.ChiTietPhieuNhaps
                .Where(x => x.SoPN == id)
                .ToListAsync();

            return View(phieuNhap);
        }

        // GET: PhieuNhap/Create
        public IActionResult Create()
        {
            ViewBag.NCC = _context.NCCs.ToList();
            ViewBag.NL = _context.KhoTongs.ToList();

            string soPN = "PN0001";

            var last = _context.PhieuNhaps
                .OrderByDescending(x => x.SoPN)
                .FirstOrDefault();

            if (last != null)
            {
                int stt = int.Parse(last.SoPN.Substring(2)) + 1;
                soPN = "PN" + stt.ToString("D4");
            }

            ViewBag.SoPN = soPN;

            return View();
        }

        // POST: PhieuNhap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            PhieuNhap phieuNhap,
            string[] MaNL,
            int[] SLNhap,
            decimal[] DGNhap)
        {
            if (ModelState.IsValid)
            {
                // Tạo mã phiếu nhập tự động
                string soPN = "PN0001";

                var last = await _context.PhieuNhaps
                    .OrderByDescending(x => x.SoPN)
                    .FirstOrDefaultAsync();

                if (last != null)
                {
                    int stt = int.Parse(last.SoPN.Substring(2)) + 1;
                    soPN = "PN" + stt.ToString("D4");
                }

                phieuNhap.SoPN = soPN;

                _context.PhieuNhaps.Add(phieuNhap);

                if (MaNL != null)
                {
                    for (int i = 0; i < MaNL.Length; i++)
                    {
                        var ct = new ChiTietPhieuNhap
                        {
                            SoPN = soPN,
                            MaNL = MaNL[i],
                            SLNhap = SLNhap[i],
                            DGNhap = DGNhap[i]
                        };

                        _context.ChiTietPhieuNhaps.Add(ct);

                        // Cập nhật tồn kho
                        var nl = await _context.KhoTongs
                            .FirstOrDefaultAsync(x => x.MaNL == MaNL[i]);

                        if (nl != null)
                        {
                            nl.SoLuongTon += SLNhap[i];
                        }
                    }
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.NCC = _context.NCCs.ToList();
            ViewBag.NL = _context.KhoTongs.ToList();

            string soPNMoi = "PN0001";

            var lastPN = await _context.PhieuNhaps
                .OrderByDescending(x => x.SoPN)
                .FirstOrDefaultAsync();

            if (lastPN != null)
            {
                int stt = int.Parse(lastPN.SoPN.Substring(2)) + 1;
                soPNMoi = "PN" + stt.ToString("D4");
            }

            ViewBag.SoPN = soPNMoi;

            return View(phieuNhap);
        }

        // GET: PhieuNhap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuNhap = await _context.PhieuNhaps.FindAsync(id);
            if (phieuNhap == null)
            {
                return NotFound();
            }
            return View(phieuNhap);
        }

        // POST: PhieuNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SoPN,NgayNhap,GiaoHang,GhiChuPN,MaNV,MaNCC")] PhieuNhap phieuNhap)
        {
            if (id != phieuNhap.SoPN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuNhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuNhapExists(phieuNhap.SoPN))
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
            return View(phieuNhap);
        }

        // GET: PhieuNhap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuNhap = await _context.PhieuNhaps
                .FirstOrDefaultAsync(m => m.SoPN == id);
            if (phieuNhap == null)
            {
                return NotFound();
            }

            return View(phieuNhap);
        }

        // POST: PhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phieuNhap = await _context.PhieuNhaps.FindAsync(id);

            if (phieuNhap != null)
            {
                var chiTiet = await _context.ChiTietPhieuNhaps
                    .Where(x => x.SoPN == id)
                    .ToListAsync();

                _context.ChiTietPhieuNhaps.RemoveRange(chiTiet);

                _context.PhieuNhaps.Remove(phieuNhap);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PhieuNhapExists(string id)
        {
            return _context.PhieuNhaps.Any(e => e.SoPN == id);
        }
    }
}
