using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class LoaiKH
    {
        [Key]
        public string MaLoaiKH { get; set; }

        [Required]
        public string TenLoaiKH { get; set; }

        public double GiamGia { get; set; }

        public int SoLuongTon { get; set; }

        public string GhiChuLoaiKH { get; set; }

        public ICollection<KhachHang> KhachHangs { get; set; }
    }
}