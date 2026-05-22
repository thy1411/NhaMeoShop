using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class PhieuXuat
    {
        [Key]
        public string SoPX { get; set; }

        public DateTime NgayXuat { get; set; }

        public string XuatHang { get; set; }

        public string GhiChuPX { get; set; }

        public ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}