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
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string loai)
        {
            var dsNhanVien = _context.NhanViens.AsQueryable();

            // LỌC LOẠI NHÂN VIÊN
            if (!string.IsNullOrEmpty(loai))
            {
                dsNhanVien = dsNhanVien
                    .Where(x => x.MaLoaiNV == loai);
            }

            ViewBag.LoaiDangChon = loai;

            return View(await dsNhanVien.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .FirstOrDefaultAsync(m => m.MaNV == id);

            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            LoadLoaiNhanVien();
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("MaNV,TenNV,PhaiNV,NgaySinhNV,SoDTNV,DiaChiNV,CCCD,TKNganHangNV,TenNganHangNV,GhiChuNV,MaLoaiNV")]
            NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            LoadLoaiNhanVien();
            return View(nhanVien);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);

            if (nhanVien == null)
            {
                return NotFound();
            }

            LoadLoaiNhanVien();

            return View(nhanVien);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            string id,
            [Bind("MaNV,TenNV,PhaiNV,NgaySinhNV,SoDTNV,DiaChiNV,CCCD,TKNganHangNV,TenNganHangNV,GhiChuNV,MaLoaiNV")]
            NhanVien nhanVien)
        {
            if (id != nhanVien.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.MaNV))
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

            LoadLoaiNhanVien();

            return View(nhanVien);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .FirstOrDefaultAsync(m => m.MaNV == id);

            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);

            _context.NhanViens.Remove(nhanVien);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(string id)
        {
            return _context.NhanViens.Any(e => e.MaNV == id);
        }

        // LOAD DROPDOWN LOẠI NHÂN VIÊN
        private void LoadLoaiNhanVien()
        {
            ViewBag.LoaiNhanVien = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "PV",
                    Text = "Phục vụ"
                },

                new SelectListItem
                {
                    Value = "TN",
                    Text = "Thu ngân"
                },

                new SelectListItem
                {
                    Value = "PC",
                    Text = "Pha chế"
                },

                new SelectListItem
                {
                    Value = "QL",
                    Text = "Quản lí"
                }
            };
        }
    }
}