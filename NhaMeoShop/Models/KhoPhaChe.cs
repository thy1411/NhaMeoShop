using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMeoShop.Models
{
    public class KhoPhaChe
    {
        [Key]
        public string MaKhoPC { get; set; }

        public string MaNL { get; set; }

        public int SoLuongTon { get; set; }

        public DateTime NgayCapNhat { get; set; }

        public string GhiChuKhoPC { get; set; }

        [ForeignKey("MaNL")]
        public KhoTong KhoTong { get; set; }
    }
}