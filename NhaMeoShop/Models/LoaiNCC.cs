using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NhaMeoShop.Models
{
    public class LoaiNCC
    {
        [Key]
        public string MaLoaiNCC { get; set; }

        [Required]
        public string TenLoaiNCC { get; set; }

        public string GhiChu { get; set; }

        public ICollection<NCC> NCCs { get; set; }
    }
}