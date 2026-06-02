using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMeoShop.Models
{
    public class ChiTietPhieuXuat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SoPX { get; set; }

        [ForeignKey("SoPX")]
        public virtual PhieuXuat PhieuXuat { get; set; }

        [Required]
        public string MaNL { get; set; }

        [ForeignKey("MaNL")]
        public virtual KhoTong KhoTong { get; set; }

        public int SLXuat { get; set; }

        public string GhiChuXuat { get; set; }

        public string MaKhoPC { get; set; }

        [ForeignKey("MaKhoPC")]
        public virtual KhoPhaChe KhoPhaChe { get; set; }
    }
}