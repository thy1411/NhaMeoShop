using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class HoaDon
    {
        [Key]
        public string SoHD { get; set; }

        public DateTime NgayLap { get; set; }

        public double PhuPhi { get; set; }

        public double KhuyenMai { get; set; }

        public bool HinhThuc { get; set; }

        public bool HinhThucTT { get; set; }

        public bool TrangThai { get; set; }

        public string GhiChuHD { get; set; }

        public string MaKH { get; set; }

        public KhachHang KhachHang { get; set; }

        public string MaNV { get; set; }

        public NhanVien NhanVien { get; set; }

        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}