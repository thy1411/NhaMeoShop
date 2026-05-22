using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class ChiTietPhieuXuat
    {
        [Key]
        public int Id { get; set; }

        public string SoPX { get; set; }

        public PhieuXuat PhieuXuat { get; set; }

        public string MaKhoPC { get; set; }

        public KhoPhaChe KhoPhaChe { get; set; }

        public int SLXuat { get; set; }

        public string GhiChuXuat { get; set; }
    }
}