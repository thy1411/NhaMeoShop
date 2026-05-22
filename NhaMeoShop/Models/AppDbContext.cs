using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NhaMeoShop.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

        public DbSet<SanPham> SanPhams { get; set; }

        public DbSet<LoaiNhanVien> LoaiNhanViens { get; set; }

        public DbSet<NhanVien> NhanViens { get; set; }

        public DbSet<HoaDon> HoaDons { get; set; }

        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }

        public DbSet<LoaiKH> LoaiKHs { get; set; }

        public DbSet<LoaiNCC> LoaiNCCs { get; set; }

        public DbSet<NCC> NCCs { get; set; }

        public DbSet<PhieuNhap> PhieuNhaps { get; set; }

        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        public DbSet<PhieuXuat> PhieuXuats { get; set; }

        public DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}