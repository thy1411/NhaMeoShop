using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class NCC
    {
        [Key]
        public string MaNCC { get; set; }

        [Required]
        public string TenNCC { get; set; }

        public string DiaChiNCC { get; set; }

        public string SoTKNCC { get; set; }

        public string TenTKNCC { get; set; }

        public string GhiChuNCC { get; set; }

        public string MaLoaiNCC { get; set; }

        public LoaiNCC LoaiNCC { get; set; }

        public ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}