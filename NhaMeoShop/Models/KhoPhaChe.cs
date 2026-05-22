using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class KhoPhaChe
    {
        [Key]
        public string MaKhoPC { get; set; }

        public decimal SLTonQuy { get; set; }

        public DateTime NgayCapNhat { get; set; }

        public string GhiChuKhoPC { get; set; }
    }
}