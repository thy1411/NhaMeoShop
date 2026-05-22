using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NhaMeoShop.Migrations
{
    public partial class TaoCSDLNhaMeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhoPhaChe",
                columns: table => new
                {
                    MaKhoPC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SLTonQuy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChuKhoPC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoPhaChe", x => x.MaKhoPC);
                });

            migrationBuilder.CreateTable(
                name: "KhoTong",
                columns: table => new
                {
                    MaNL = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonViNhapNL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViSuDungNL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiLeQuyDoi = table.Column<float>(type: "real", nullable: false),
                    DonGiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GhiChuNL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoTong", x => x.MaNL);
                });

            migrationBuilder.CreateTable(
                name: "LoaiKHs",
                columns: table => new
                {
                    MaLoaiKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiamGia = table.Column<double>(type: "float", nullable: false),
                    GhiChuLoaiKH = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiKHs", x => x.MaLoaiKH);
                });

            migrationBuilder.CreateTable(
                name: "LoaiNCCs",
                columns: table => new
                {
                    MaLoaiNCC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiNCC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiNCCs", x => x.MaLoaiNCC);
                });

            migrationBuilder.CreateTable(
                name: "LoaiNhanViens",
                columns: table => new
                {
                    MaLoaiNV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiNV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeSoLuongNV = table.Column<double>(type: "float", nullable: false),
                    GhiChuLoaiNV = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiNhanViens", x => x.MaLoaiNV);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    MaLoaiSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChuLoaiSP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.MaLoaiSP);
                });

            migrationBuilder.CreateTable(
                name: "PhieuXuats",
                columns: table => new
                {
                    SoPX = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayXuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    XuatHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuPX = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuXuats", x => x.SoPX);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinhKH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDTKH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDKTV = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChuKH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiKH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiKHMaLoaiKH = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKH);
                    table.ForeignKey(
                        name: "FK_KhachHangs_LoaiKHs_LoaiKHMaLoaiKH",
                        column: x => x.LoaiKHMaLoaiKH,
                        principalTable: "LoaiKHs",
                        principalColumn: "MaLoaiKH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NCCs",
                columns: table => new
                {
                    MaNCC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNCC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiNCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTKNCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTKNCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuNCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiNCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiNCCMaLoaiNCC = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCCs", x => x.MaNCC);
                    table.ForeignKey(
                        name: "FK_NCCs_LoaiNCCs_LoaiNCCMaLoaiNCC",
                        column: x => x.LoaiNCCMaLoaiNCC,
                        principalTable: "LoaiNCCs",
                        principalColumn: "MaLoaiNCC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhaiNV = table.Column<bool>(type: "bit", nullable: false),
                    NgaySinhNV = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDTNV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiNV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TKNganHangNV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNganHangNV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuNV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiNV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiNhanVienMaLoaiNV = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanViens_LoaiNhanViens_LoaiNhanVienMaLoaiNV",
                        column: x => x.LoaiNhanVienMaLoaiNV,
                        principalTable: "LoaiNhanViens",
                        principalColumn: "MaLoaiNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGiaSP = table.Column<double>(type: "float", nullable: false),
                    HinhAnhSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiSP = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_MaLoaiSP",
                        column: x => x.MaLoaiSP,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "MaLoaiSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuXuats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhieuXuatSoPX = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaKhoPC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoPhaCheMaKhoPC = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SLXuat = table.Column<int>(type: "int", nullable: false),
                    GhiChuXuat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuXuats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuats_KhoPhaChe_KhoPhaCheMaKhoPC",
                        column: x => x.KhoPhaCheMaKhoPC,
                        principalTable: "KhoPhaChe",
                        principalColumn: "MaKhoPC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuats_PhieuXuats_PhieuXuatSoPX",
                        column: x => x.PhieuXuatSoPX,
                        principalTable: "PhieuXuats",
                        principalColumn: "SoPX",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    SoHD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhuPhi = table.Column<double>(type: "float", nullable: false),
                    KhuyenMai = table.Column<double>(type: "float", nullable: false),
                    HinhThuc = table.Column<bool>(type: "bit", nullable: false),
                    HinhThucTT = table.Column<bool>(type: "bit", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    GhiChuHD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaKH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhachHangMaKH = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaNV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienMaNV = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.SoHD);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_KhachHangMaKH",
                        column: x => x.KhachHangMaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDons_NhanViens_NhanVienMaNV",
                        column: x => x.NhanVienMaNV,
                        principalTable: "NhanViens",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhaps",
                columns: table => new
                {
                    SoPN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiaoHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuPN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanVienMaNV = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaNCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NCCMaNCC = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhaps", x => x.SoPN);
                    table.ForeignKey(
                        name: "FK_PhieuNhaps_NCCs_NCCMaNCC",
                        column: x => x.NCCMaNCC,
                        principalTable: "NCCs",
                        principalColumn: "MaNCC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuNhaps_NhanViens_NhanVienMaNV",
                        column: x => x.NhanVienMaNV,
                        principalTable: "NhanViens",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoaDonSoHD = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SanPhamMaSP = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SLBan = table.Column<int>(type: "int", nullable: false),
                    DGBan = table.Column<double>(type: "float", nullable: false),
                    GhiChuHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_HoaDonSoHD",
                        column: x => x.HoaDonSoHD,
                        principalTable: "HoaDons",
                        principalColumn: "SoHD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_SanPhams_SanPhamMaSP",
                        column: x => x.SanPhamMaSP,
                        principalTable: "SanPhams",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhieuNhapSoPN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaNL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoTongMaNL = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SLNhap = table.Column<int>(type: "int", nullable: false),
                    DGNhap = table.Column<double>(type: "float", nullable: false),
                    GhiChuNhap = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuNhaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_KhoTong_KhoTongMaNL",
                        column: x => x.KhoTongMaNL,
                        principalTable: "KhoTong",
                        principalColumn: "MaNL",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhaps_PhieuNhaps_PhieuNhapSoPN",
                        column: x => x.PhieuNhapSoPN,
                        principalTable: "PhieuNhaps",
                        principalColumn: "SoPN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_HoaDonSoHD",
                table: "ChiTietHoaDons",
                column: "HoaDonSoHD");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_SanPhamMaSP",
                table: "ChiTietHoaDons",
                column: "SanPhamMaSP");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_KhoTongMaNL",
                table: "ChiTietPhieuNhaps",
                column: "KhoTongMaNL");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhaps_PhieuNhapSoPN",
                table: "ChiTietPhieuNhaps",
                column: "PhieuNhapSoPN");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuats_KhoPhaCheMaKhoPC",
                table: "ChiTietPhieuXuats",
                column: "KhoPhaCheMaKhoPC");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuats_PhieuXuatSoPX",
                table: "ChiTietPhieuXuats",
                column: "PhieuXuatSoPX");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_KhachHangMaKH",
                table: "HoaDons",
                column: "KhachHangMaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_NhanVienMaNV",
                table: "HoaDons",
                column: "NhanVienMaNV");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_LoaiKHMaLoaiKH",
                table: "KhachHangs",
                column: "LoaiKHMaLoaiKH");

            migrationBuilder.CreateIndex(
                name: "IX_NCCs_LoaiNCCMaLoaiNCC",
                table: "NCCs",
                column: "LoaiNCCMaLoaiNCC");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_LoaiNhanVienMaLoaiNV",
                table: "NhanViens",
                column: "LoaiNhanVienMaLoaiNV");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_NCCMaNCC",
                table: "PhieuNhaps",
                column: "NCCMaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_NhanVienMaNV",
                table: "PhieuNhaps",
                column: "NhanVienMaNV");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaLoaiSP",
                table: "SanPhams",
                column: "MaLoaiSP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhaps");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuXuats");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "KhoTong");

            migrationBuilder.DropTable(
                name: "PhieuNhaps");

            migrationBuilder.DropTable(
                name: "KhoPhaChe");

            migrationBuilder.DropTable(
                name: "PhieuXuats");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");

            migrationBuilder.DropTable(
                name: "NCCs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "LoaiKHs");

            migrationBuilder.DropTable(
                name: "LoaiNCCs");

            migrationBuilder.DropTable(
                name: "LoaiNhanViens");
        }
    }
}
