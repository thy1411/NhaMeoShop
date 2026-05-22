using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class PhieuNhap
    {
        [Key]
        public string SoPN { get; set; }

        public DateTime NgayNhap { get; set; }

        public string GiaoHang { get; set; }

        public string GhiChuPN { get; set; }

        public string MaNV { get; set; }

        public NhanVien NhanVien { get; set; }

        public string MaNCC { get; set; }

        public NCC NCC { get; set; }

        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}