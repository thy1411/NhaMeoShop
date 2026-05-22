using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class ChiTietPhieuNhap
    {
        [Key]
        public int Id { get; set; }

        public string SoPN { get; set; }

        public PhieuNhap PhieuNhap { get; set; }

        public string MaNL { get; set; }

        public KhoTong KhoTong { get; set; }

        public int SLNhap { get; set; }

        public double DGNhap { get; set; }

        public string GhiChuNhap { get; set; }
    }
}