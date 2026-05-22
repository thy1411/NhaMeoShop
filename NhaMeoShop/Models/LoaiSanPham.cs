using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class LoaiSanPham
    {
        [Key]
        public string MaLoaiSP { get; set; }

        [Required]
        public string TenLoaiSP { get; set; }

        public string GhiChuLoaiSP { get; set; }
    }
}