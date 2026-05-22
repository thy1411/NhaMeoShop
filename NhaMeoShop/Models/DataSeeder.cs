using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhaMeoShop.Models
{
    public class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // =========================
            // LOẠI SẢN PHẨM
            // =========================

            if (!context.LoaiSanPhams.Any())
            {
                context.LoaiSanPhams.AddRange(

                    new LoaiSanPham { MaLoaiSP = "CF", TenLoaiSP = "Cà phê" },
                    new LoaiSanPham { MaLoaiSP = "TS", TenLoaiSP = "Trà sữa" },
                    new LoaiSanPham { MaLoaiSP = "NE", TenLoaiSP = "Nước ép" },
                    new LoaiSanPham { MaLoaiSP = "ST", TenLoaiSP = "Sinh tố" },
                    new LoaiSanPham { MaLoaiSP = "TC", TenLoaiSP = "Trà trái cây" },
                    new LoaiSanPham { MaLoaiSP = "TP", TenLoaiSP = "Topping" }

                );

                context.SaveChanges();
            }

            // =========================
            // SẢN PHẨM
            // =========================

            if (!context.SanPhams.Any())
            {
                context.SanPhams.AddRange(

                    new SanPham { MaSP = "CP001", TenSP = "Cà phê đá", DonGiaSP = 15000, HinhAnhSP = "CP001.png", MaLoaiSP = "CF" },
                    new SanPham { MaSP = "CP002", TenSP = "Cà phê sữa", DonGiaSP = 18000, HinhAnhSP = "CP002.png", MaLoaiSP = "CF" },
                    new SanPham { MaSP = "CP003", TenSP = "Bạc xỉu", DonGiaSP = 20000, HinhAnhSP = "CP003.png", MaLoaiSP = "CF" },
                    new SanPham { MaSP = "CP004", TenSP = "Cà phê muối", DonGiaSP = 22000, HinhAnhSP = "CP004.png", MaLoaiSP = "CF" },
                    new SanPham { MaSP = "CP005", TenSP = "Americano", DonGiaSP = 25000, HinhAnhSP = "CP005.png", MaLoaiSP = "CF" },

                    new SanPham { MaSP = "TS001", TenSP = "Trà sữa truyền thống", DonGiaSP = 18000, HinhAnhSP = "TS001.png", MaLoaiSP = "TS" },
                    new SanPham { MaSP = "TS002", TenSP = "Trà sữa kem trứng", DonGiaSP = 20000, HinhAnhSP = "TS002.png", MaLoaiSP = "TS" },
                    new SanPham { MaSP = "TS003", TenSP = "Trà sữa matcha", DonGiaSP = 20000, HinhAnhSP = "TS003.png", MaLoaiSP = "TS" },
                    new SanPham { MaSP = "TS004", TenSP = "Trà sữa phô mai tươi", DonGiaSP = 20000, HinhAnhSP = "TS004.png", MaLoaiSP = "TS" },
                    new SanPham { MaSP = "TS005", TenSP = "Trà sữa olong", DonGiaSP = 18000, HinhAnhSP = "TS005.png", MaLoaiSP = "TS" },

                    new SanPham { MaSP = "NE001", TenSP = "Nước ép táo", DonGiaSP = 20000, HinhAnhSP = "NE001.png", MaLoaiSP = "NE" },
                    new SanPham { MaSP = "NE002", TenSP = "Nước ép thơm", DonGiaSP = 20000, HinhAnhSP = "NE002.png", MaLoaiSP = "NE" },
                    new SanPham { MaSP = "NE003", TenSP = "Nước ép cam", DonGiaSP = 15000, HinhAnhSP = "NE003.png", MaLoaiSP = "NE" },
                    new SanPham { MaSP = "NE004", TenSP = "Nước ép dưa hấu", DonGiaSP = 20000, HinhAnhSP = "NE004.png", MaLoaiSP = "NE" },
                    new SanPham { MaSP = "NE005", TenSP = "Nước ép cà rốt", DonGiaSP = 20000, HinhAnhSP = "NE005.png", MaLoaiSP = "NE" },
                    new SanPham { MaSP = "NE006", TenSP = "Nước ép ổi", DonGiaSP = 20000, HinhAnhSP = "NE006.png", MaLoaiSP = "NE" },

                    new SanPham { MaSP = "ST001", TenSP = "Sinh tố bơ", DonGiaSP = 25000, HinhAnhSP = "ST001.png", MaLoaiSP = "ST" },
                    new SanPham { MaSP = "ST002", TenSP = "Sinh tố sầu riêng", DonGiaSP = 28000, HinhAnhSP = "ST002.png", MaLoaiSP = "ST" },
                    new SanPham { MaSP = "ST003", TenSP = "Sinh tố dâu", DonGiaSP = 25000, HinhAnhSP = "ST003.png", MaLoaiSP = "ST" },
                    new SanPham { MaSP = "ST004", TenSP = "Sinh tố dừa", DonGiaSP = 25000, HinhAnhSP = "ST004.png", MaLoaiSP = "ST" },
                    new SanPham { MaSP = "ST005", TenSP = "Sinh tố sapoche", DonGiaSP = 25000, HinhAnhSP = "ST005.png", MaLoaiSP = "ST" },

                    new SanPham { MaSP = "TC001", TenSP = "Trà cherry", DonGiaSP = 25000, HinhAnhSP = "TC001.png", MaLoaiSP = "TC" },
                    new SanPham { MaSP = "TC002", TenSP = "Trà dâu ổi hồng", DonGiaSP = 25000, HinhAnhSP = "TC002.png", MaLoaiSP = "TC" },
                    new SanPham { MaSP = "TC003", TenSP = "Trà đào cam sả", DonGiaSP = 25000, HinhAnhSP = "TC003.png", MaLoaiSP = "TC" },
                    new SanPham { MaSP = "TC004", TenSP = "Trà nhiệt đới", DonGiaSP = 25000, HinhAnhSP = "TC004.png", MaLoaiSP = "TC" },
                    new SanPham { MaSP = "TC005", TenSP = "Trà tắc cam xí muội", DonGiaSP = 25000, HinhAnhSP = "TC005.png", MaLoaiSP = "TC" },
                    new SanPham { MaSP = "TC006", TenSP = "Trà xanh dưa lưới", DonGiaSP = 25000, HinhAnhSP = "TC006.png", MaLoaiSP = "TC" },
                    new SanPham { MaSP = "TC007", TenSP = "Trà vải hoa hồng", DonGiaSP = 25000, HinhAnhSP = "TC007.png", MaLoaiSP = "TC" },

                    new SanPham { MaSP = "TP001", TenSP = "Trân châu đen", DonGiaSP = 5000, HinhAnhSP = "TP001.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP002", TenSP = "Trân châu trắng", DonGiaSP = 5000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" }

                );

                context.SaveChanges();
            }

            // =========================
            // LOẠI NHÂN VIÊN
            // =========================

            if (!context.LoaiNhanViens.Any())
            {
                context.LoaiNhanViens.AddRange(

                    new LoaiNhanVien { MaLoaiNV = "PV", TenLoaiNV = "Phục vụ", HeSoLuongNV = 1 },
                    new LoaiNhanVien { MaLoaiNV = "PC", TenLoaiNV = "Pha chế", HeSoLuongNV = 1.5 },
                    new LoaiNhanVien { MaLoaiNV = "QK", TenLoaiNV = "Quản lý kho", HeSoLuongNV = 1.5 },
                    new LoaiNhanVien { MaLoaiNV = "TN", TenLoaiNV = "Thu ngân", HeSoLuongNV = 1.5 },
                    new LoaiNhanVien { MaLoaiNV = "CS", TenLoaiNV = "Chăm sóc", HeSoLuongNV = 2 }

                );

                context.SaveChanges();
            }

            // =========================
            // NHÂN VIÊN
            // =========================

            if (!context.NhanViens.Any())
            {
                context.NhanViens.AddRange(

                    new NhanVien
                    {
                        MaNV = "PV0001",
                        TenNV = "Trần A",
                        PhaiNV = false,
                        NgaySinhNV = new DateTime(2005, 11, 14),
                        SoDTNV = "0997381926",
                        DiaChiNV = "Quận 4",
                        CCCD = "92640113",
                        TKNganHangNV = "17047126",
                        TenNganHangNV = "Techcombank",
                        MaLoaiNV = "PV"
                    },

                    new NhanVien
                    {
                        MaNV = "PV0002",
                        TenNV = "Lý B",
                        PhaiNV = true,
                        NgaySinhNV = new DateTime(2005, 11, 15),
                        SoDTNV = "0997381927",
                        DiaChiNV = "Quận 5",
                        CCCD = "92640114",
                        TKNganHangNV = "17047127",
                        TenNganHangNV = "Techcombank",
                        MaLoaiNV = "PV"
                    },

                    new NhanVien
                    {
                        MaNV = "PC0001",
                        TenNV = "Nguyễn C",
                        PhaiNV = true,
                        NgaySinhNV = new DateTime(2005, 11, 16),
                        SoDTNV = "0997381928",
                        DiaChiNV = "Quận 6",
                        CCCD = "92640115",
                        TKNganHangNV = "17047128",
                        TenNganHangNV = "Techcombank",
                        MaLoaiNV = "PC"
                    }

                );

                context.SaveChanges();
            }

            // =========================
            // LOẠI KHÁCH HÀNG
            // =========================

            if (!context.LoaiKHs.Any())
            {
                context.LoaiKHs.AddRange(

                    new LoaiKH
                    {
                        MaLoaiKH = "TV",
                        TenLoaiKH = "Khách hàng thành viên",
                        GhiChuLoaiKH = ""
                    },

                    new LoaiKH
                    {
                        MaLoaiKH = "VL",
                        TenLoaiKH = "Khách vãng lai",
                        GhiChuLoaiKH = ""
                    }

                );

                context.SaveChanges();
            }

            // =========================
            // LOẠI NCC
            // =========================

            if (!context.LoaiNCCs.Any())
            {
                context.LoaiNCCs.AddRange(

                    new LoaiNCC
                    {
                        MaLoaiNCC = "NL",
                        TenLoaiNCC = "Nguyên liệu",
                        GhiChu = ""
                    },

                    new LoaiNCC
                    {
                        MaLoaiNCC = "BB",
                        TenLoaiNCC = "Bao bì",
                        GhiChu = ""
                    },

                    new LoaiNCC
                    {
                        MaLoaiNCC = "PT",
                        TenLoaiNCC = "Thức ăn thú cưng",
                        GhiChu = ""
                    }

                );

                context.SaveChanges();
            }

            // =========================
            // NHÀ CUNG CẤP
            // =========================

            if (!context.NCCs.Any())
            {
                context.NCCs.AddRange(

                    new NCC
                    {
                        MaNCC = "NCCAA00001",
                        TenNCC = "Công ty nguyên liệu TT",
                        DiaChiNCC = "111 Lê Văn Xuân",
                        SoTKNCC = "112233445566",
                        TenTKNCC = "Techcombank",
                        GhiChuNCC = "",
                        MaLoaiNCC = "NL"
                    },

                    new NCC
                    {
                        MaNCC = "NCCAA00002",
                        TenNCC = "Công ty bao bì ly nhựa",
                        DiaChiNCC = "222 Nguyễn Văn A",
                        SoTKNCC = "998877665544",
                        TenTKNCC = "Vietcombank",
                        GhiChuNCC = "",
                        MaLoaiNCC = "BB"
                    }

                );

                context.SaveChanges();
            }
        }
    }
}