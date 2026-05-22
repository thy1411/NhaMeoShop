using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class NhanVien
    {
        [Key]
        public string MaNV { get; set; }

        [Required]
        public string TenNV { get; set; }

        public bool PhaiNV { get; set; }

        public DateTime NgaySinhNV { get; set; }

        public string SoDTNV { get; set; }

        public string DiaChiNV { get; set; }

        public string CCCD { get; set; }

        public string TKNganHangNV { get; set; }

        public string TenNganHangNV { get; set; }

        public string GhiChuNV { get; set; }

        public string MaLoaiNV { get; set; }

        public LoaiNhanVien LoaiNhanVien { get; set; }
    }
}