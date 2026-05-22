using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMeoShop.Models
{
    public class SanPham
    {
        [Key]
        public string MaSP { get; set; }

        [Required]
        public string TenSP { get; set; }

        public double DonGiaSP { get; set; }

        public string HinhAnhSP { get; set; }

        public string GhiChuSP { get; set; }

        [Required]
        public string MaLoaiSP { get; set; }

        [ForeignKey("MaLoaiSP")]
        public LoaiSanPham LoaiSanPham { get; set; }
    }
}