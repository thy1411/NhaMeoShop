using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class KhoTong
    {
        [Key]
        public string MaNL { get; set; }

        [Required]
        public string TenNL { get; set; }

        public string DonViNhapNL { get; set; }

        public string DonViSuDungNL { get; set; }

        public float TiLeQuyDoi { get; set; }

        public decimal DonGiaNhap { get; set; }

        public string GhiChuNL { get; set; }
    }
}