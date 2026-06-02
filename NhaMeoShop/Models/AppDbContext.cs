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
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
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

        public DbSet<KhoTong> KhoTongs { get; set; }
        public DbSet<KhoPhaChe> KhoPhaChes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CHI TIET PHIEU NHAP
            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasOne(x => x.PhieuNhap)
                .WithMany()
                .HasForeignKey(x => x.SoPN)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasOne(x => x.KhoTong)
                .WithMany()
                .HasForeignKey(x => x.MaNL)
                .HasPrincipalKey(x => x.MaNL);

            // CHI TIET PHIEU XUAT
            modelBuilder.Entity<ChiTietPhieuXuat>()
                .HasOne(x => x.PhieuXuat)
                .WithMany(x => x.ChiTietPhieuXuats)
                .HasForeignKey(x => x.SoPX)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChiTietPhieuXuat>()
                .HasOne(x => x.KhoTong)
                .WithMany()
                .HasForeignKey(x => x.MaNL)
                .HasPrincipalKey(x => x.MaNL);

            modelBuilder.Entity<ChiTietPhieuXuat>()
                .HasOne(x => x.KhoPhaChe)
                .WithMany()
                .HasForeignKey(x => x.MaKhoPC)
                .HasPrincipalKey(x => x.MaKhoPC);
        }
    }
}