using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class KhachHang
    {
        [Key]
        public string MaKH { get; set; }

        [Required]
        public string TenKH { get; set; }

        public DateTime NgaySinhKH { get; set; }

        public string SoDTKH { get; set; }

        public DateTime NgayDKTV { get; set; }

        public string GhiChuKH { get; set; }

        public string MaLoaiKH { get; set; }

        public LoaiKH LoaiKH { get; set; }

        public ICollection<HoaDon> HoaDons { get; set; }
    }
}