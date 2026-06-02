using NhaMeoShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NhaMeoShop.Models
{
    public class ChiTietPhieuNhap
    {
        [Key]
        public int Id { get; set; }

        public string SoPN { get; set; }
        public virtual PhieuNhap PhieuNhap { get; set; }

        public string MaNL { get; set; }
        public virtual KhoTong KhoTong { get; set; }

        public int SLNhap { get; set; }

        public decimal DGNhap { get; set; }

        public string GhiChuNhap { get; set; }
    }
}