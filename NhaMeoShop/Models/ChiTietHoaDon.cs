using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int Id { get; set; }

        public string SoHD { get; set; }

        public HoaDon HoaDon { get; set; }

        public string MaSP { get; set; }

        public SanPham SanPham { get; set; }

        public int SLBan { get; set; }

        public double DGBan { get; set; }

        public string GhiChuHoaDon { get; set; }
    }
}