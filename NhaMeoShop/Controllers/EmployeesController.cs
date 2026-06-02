using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NhaMeoShop.Models;

namespace NhaMeoShop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployeesController(
            AppDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string loai)
        {
            var dsNhanVien = _context.NhanViens.AsQueryable();

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
                .Include(x => x.LoaiNhanVien)
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
            [Bind("MaNV,TenNV,PhaiNV,NgaySinhNV,SoDTNV,DiaChiNV,CCCD,TKNganHangNV,TenNganHangNV,GhiChuNV,MaLoaiNV,UserNameNV,PasswordNV,KichHoatTK")]
            NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra username tồn tại
                var checkUser =
                    await _userManager.FindByNameAsync(
                        nhanVien.UserNameNV);

                if (checkUser != null)
                {
                    ModelState.AddModelError(
                        "",
                        "Tên đăng nhập đã tồn tại."
                    );

                    LoadLoaiNhanVien();
                    return View(nhanVien);
                }

                var user = new IdentityUser
                {
                    UserName = nhanVien.UserNameNV,
                    Email = nhanVien.UserNameNV + "@nhameoshop.local",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(
                    user,
                    nhanVien.PasswordNV
                );

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(
                            "",
                            error.Description
                        );
                    }

                    LoadLoaiNhanVien();
                    return View(nhanVien);
                }

                await _userManager.AddToRoleAsync(
                    user,
                    "Staff"
                );

                _context.NhanViens.Add(nhanVien);

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

            var nhanVien =
                await _context.NhanViens.FindAsync(id);

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
            [Bind("MaNV,TenNV,PhaiNV,NgaySinhNV,SoDTNV,DiaChiNV,CCCD,TKNganHangNV,TenNganHangNV,GhiChuNV,MaLoaiNV,UserNameNV,PasswordNV,KichHoatTK")]
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

                    throw;
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
        public async Task<IActionResult> DeleteConfirmed(
            string id)
        {
            var nhanVien =
                await _context.NhanViens.FindAsync(id);

            if (nhanVien != null)
            {
                var user =
                    await _userManager.FindByNameAsync(
                        nhanVien.UserNameNV);

                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }

                _context.NhanViens.Remove(nhanVien);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(string id)
        {
            return _context.NhanViens.Any(
                e => e.MaNV == id);
        }

        private void LoadLoaiNhanVien()
        {
            ViewBag.MaLoaiNV = new List<SelectListItem>
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
            Value = "QK",
            Text = "Quản kho"
        },

        new SelectListItem
        {
            Value = "CS",
            Text = "Chăm sóc"
        }
    };
        }
    }
}