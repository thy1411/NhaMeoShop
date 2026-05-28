using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhaMeoShop.Models
{
    public class CartItem
    {
        public SanPham SanPham { get; set; }

        public int SoLuong { get; set; }
    }
}