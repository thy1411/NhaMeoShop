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
                    new SanPham { MaSP = "TP002", TenSP = "Trân châu trắng", DonGiaSP = 5000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP003", TenSP = "Thạch cá", DonGiaSP = 5000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP004", TenSP = "Thạch trái cây", DonGiaSP = 5000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP005", TenSP = "Thạch táo", DonGiaSP = 5000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP006", TenSP = "Rau Câu", DonGiaSP = 5000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP007", TenSP = "Khúc bạch", DonGiaSP = 7000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP008", TenSP = "Pudding trứng", DonGiaSP = 7000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP009", TenSP = "Pudding socola", DonGiaSP = 7000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP010", TenSP = "Pudding phô mai tươi", DonGiaSP = 7000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP011", TenSP = "Đào miếng", DonGiaSP = 8000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" },
                    new SanPham { MaSP = "TP012", TenSP = "Kem cheese", DonGiaSP = 10000, HinhAnhSP = "TP002.png", MaLoaiSP = "TP" }

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
                    },

                    new NhanVien
                    {
                        MaNV = "PC0002",
                        TenNV = "Phan D",
                        PhaiNV = false,
                        NgaySinhNV = new DateTime(2005, 11, 17),
                        SoDTNV = "0997381929",
                        DiaChiNV = "Quận 7",
                        CCCD = "92640116",
                        TKNganHangNV = "17047129",
                        TenNganHangNV = "Techcombank",
                        MaLoaiNV = "PC"
                    },

                    new NhanVien
                    {
                        MaNV = "QK0001",
                        TenNV = "Hà E",
                        PhaiNV = false,
                        NgaySinhNV = new DateTime(2005, 11, 18),
                        SoDTNV = "0997381930",
                        DiaChiNV = "Quận 8",
                        CCCD = "92640117",
                        TKNganHangNV = "17047130",
                        TenNganHangNV = "Techcombank",
                        MaLoaiNV = "QK"
                    },

                    new NhanVien
                    {
                        MaNV = "QK0002",
                        TenNV = "Ngô F",
                        PhaiNV = true,
                        NgaySinhNV = new DateTime(2005, 11, 19),
                        SoDTNV = "0997381931",
                        DiaChiNV = "Quận 9",
                        CCCD = "92640118",
                        TKNganHangNV = "17047131",
                        TenNganHangNV = "Techcombank",
                        MaLoaiNV = "QK"
                    },

                    new NhanVien
                    {
                        MaNV = "TN0001",
                        TenNV = "Trịnh I",
                        PhaiNV = false,
                        NgaySinhNV = new DateTime(2005, 11, 20),
                        SoDTNV = "0997381932",
                        DiaChiNV = "Quận 10",
                        CCCD = "92640119",
                        TKNganHangNV = "17047132",
                        TenNganHangNV = "Techcombank",
                        MaLoaiNV = "TN"
                    },

                    new NhanVien
                    {
                        MaNV = "TN0002",
                        TenNV = "Đại J",
                        PhaiNV = true,
                        NgaySinhNV = new DateTime(2005, 11, 21),
                        SoDTNV = "0997381933",
                        DiaChiNV = "Quận 11",
                        CCCD = "92640120",
                        TKNganHangNV = "17047133",
                        TenNganHangNV = "Techcombank",
                        MaLoaiNV = "TN"
                    },

                    new NhanVien
                    {
                        MaNV = "CS0001",
                        TenNV = "Hồng K",
                        PhaiNV = true,
                        NgaySinhNV = new DateTime(2005, 11, 22),
                        SoDTNV = "0997381934",
                        DiaChiNV = "Quận 12",
                        CCCD = "92640121",
                        TKNganHangNV = "17047134",
                        TenNganHangNV = "Techcombank",
                        MaLoaiNV = "CS"
                    },

                    new NhanVien
                    {
                        MaNV = "CS0002",
                        TenNV = "Quế L",
                        PhaiNV = false,
                        NgaySinhNV = new DateTime(2005, 11, 23),
                        SoDTNV = "0997381935",
                        DiaChiNV = "Quận 13",
                        CCCD = "92640122",
                        TKNganHangNV = "17047135",
                        TenNganHangNV = "Techcombank",
                        MaLoaiNV = "CS"
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
            // =========================
            // KHO TỔNG
            // =========================

            if (!context.KhoTongs.Any())
            {
                context.KhoTongs.AddRange(

                    // CÀ PHÊ
                    new KhoTong { MaNL = "CP01", TenNL = "Bột cà phê", DonViNhapNL = "Bịch 1kg", DonViSuDungNL = "Bịch", TiLeQuyDoi = 1, DonGiaNhap = 150000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "CP02", TenNL = "Sữa đặc", DonViNhapNL = "Thùng (48 lon)", DonViSuDungNL = "Lon", TiLeQuyDoi = 48, DonGiaNhap = 1100000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "CP03", TenNL = "Sữa tươi", DonViNhapNL = "Thùng (48 hộp)", DonViSuDungNL = "Hộp", TiLeQuyDoi = 48, DonGiaNhap = 1300000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "CP04", TenNL = "Kem béo", DonViNhapNL = "Thùng (12 hộp)", DonViSuDungNL = "Hộp", TiLeQuyDoi = 12, DonGiaNhap = 900000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "CP05", TenNL = "Whipping cream", DonViNhapNL = "Thùng (12 hộp)", DonViSuDungNL = "Hộp", TiLeQuyDoi = 12, DonGiaNhap = 1200000, SoLuongTon = 10, GhiChuNL = "" },

                    // TRÀ SỮA
                    new KhoTong { MaNL = "TS01", TenNL = "Trà đen", DonViNhapNL = "Bịch 500g", DonViSuDungNL = "Bịch", TiLeQuyDoi = 1, DonGiaNhap = 90000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TS02", TenNL = "Trà ô long", DonViNhapNL = "Bịch 500g", DonViSuDungNL = "Bịch", TiLeQuyDoi = 1, DonGiaNhap = 110000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TS03", TenNL = "Trà xanh", DonViNhapNL = "Bịch 500g", DonViSuDungNL = "Bịch", TiLeQuyDoi = 1, DonGiaNhap = 100000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TS04", TenNL = "Bột matcha", DonViNhapNL = "Bịch 500g", DonViSuDungNL = "Bịch", TiLeQuyDoi = 1, DonGiaNhap = 180000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TS05", TenNL = "Bột sữa", DonViNhapNL = "Bao 25kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 25, DonGiaNhap = 1800000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TS06", TenNL = "Bột béo", DonViNhapNL = "Bao 25kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 25, DonGiaNhap = 1600000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TS07", TenNL = "Trứng", DonViNhapNL = "Khay (30 quả)", DonViSuDungNL = "Quả", TiLeQuyDoi = 30, DonGiaNhap = 75000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TS08", TenNL = "Cream cheese", DonViNhapNL = "Thùng 10kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 10, DonGiaNhap = 950000, SoLuongTon = 10, GhiChuNL = "" },

                    // NƯỚC ÉP
                    new KhoTong { MaNL = "NE01", TenNL = "Táo", DonViNhapNL = "Thùng 10kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 10, DonGiaNhap = 350000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "NE02", TenNL = "Thơm", DonViNhapNL = "Thùng 10kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 10, DonGiaNhap = 180000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "NE03", TenNL = "Cam", DonViNhapNL = "Thùng 10kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 10, DonGiaNhap = 300000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "NE04", TenNL = "Dưa hấu", DonViNhapNL = "Thùng 10kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 10, DonGiaNhap = 150000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "NE05", TenNL = "Nho", DonViNhapNL = "Thùng 5kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 5, DonGiaNhap = 280000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "NE06", TenNL = "Ổi", DonViNhapNL = "Thùng 10kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 10, DonGiaNhap = 200000, SoLuongTon = 10, GhiChuNL = "" },

                    // SINH TỐ
                    new KhoTong { MaNL = "ST01", TenNL = "Bơ", DonViNhapNL = "Thùng 10kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 10, DonGiaNhap = 600000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "ST02", TenNL = "Sầu riêng", DonViNhapNL = "Thùng 5kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 5, DonGiaNhap = 500000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "ST03", TenNL = "Dâu", DonViNhapNL = "Thùng 5kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 5, DonGiaNhap = 450000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "ST04", TenNL = "Dừa", DonViNhapNL = "Thùng 20 trái", DonViSuDungNL = "Trái", TiLeQuyDoi = 20, DonGiaNhap = 200000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "ST05", TenNL = "Sapoche", DonViNhapNL = "Thùng 10kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 10, DonGiaNhap = 250000, SoLuongTon = 10, GhiChuNL = "" },

                    // TRÀ CÂY
                    new KhoTong { MaNL = "TC01", TenNL = "Trà lài", DonViNhapNL = "Bịch 500g", DonViSuDungNL = "Bịch", TiLeQuyDoi = 1, DonGiaNhap = 95000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TC02", TenNL = "Cherry", DonViNhapNL = "Hộp 1kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 1, DonGiaNhap = 150000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TC03", TenNL = "Đào ngâm", DonViNhapNL = "Thùng 12 lon", DonViSuDungNL = "Lon", TiLeQuyDoi = 12, DonGiaNhap = 550000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TC04", TenNL = "Dưa lưới", DonViNhapNL = "Kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 1, DonGiaNhap = 40000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TC05", TenNL = "Vải ngâm", DonViNhapNL = "Kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 1, DonGiaNhap = 400000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TC06", TenNL = "Tắc", DonViNhapNL = "Bịch 5kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 5, DonGiaNhap = 25000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TC07", TenNL = "Sả", DonViNhapNL = "Kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 1, DonGiaNhap = 20000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TC08", TenNL = "Xí muội", DonViNhapNL = "Kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 1, DonGiaNhap = 80000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TC09", TenNL = "Syrup trái cây", DonViNhapNL = "Chai 1L", DonViSuDungNL = "Chai", TiLeQuyDoi = 1, DonGiaNhap = 120000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "TC10", TenNL = "Mật ong", DonViNhapNL = "Chai 1L", DonViSuDungNL = "Chai", TiLeQuyDoi = 1, DonGiaNhap = 180000, SoLuongTon = 10, GhiChuNL = "" },

                    // CHUNG
                    new KhoTong { MaNL = "CB01", TenNL = "Đường", DonViNhapNL = "Bao 50kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 50, DonGiaNhap = 900000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "CB02", TenNL = "Syrup", DonViNhapNL = "Chai 1L", DonViSuDungNL = "Chai", TiLeQuyDoi = 1, DonGiaNhap = 100000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "CB03", TenNL = "Muối", DonViNhapNL = "Bao 25kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 25, DonGiaNhap = 200000, SoLuongTon = 10, GhiChuNL = "" },
                    new KhoTong { MaNL = "CB04", TenNL = "Đá viên", DonViNhapNL = "Bao 20kg", DonViSuDungNL = "Kg", TiLeQuyDoi = 20, DonGiaNhap = 40000, SoLuongTon = 10, GhiChuNL = "" }

                );

                context.SaveChanges();
            }
        }
    }
}