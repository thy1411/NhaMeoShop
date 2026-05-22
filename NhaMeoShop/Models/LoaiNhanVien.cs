using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class LoaiNhanVien
    {
        [Key]
        public string MaLoaiNV { get; set; }

        [Required]
        public string TenLoaiNV { get; set; }

        public double HeSoLuongNV { get; set; }

        public string GhiChuLoaiNV { get; set; }

        public ICollection<NhanVien> NhanViens { get; set; }
    }
}