using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperProject.Models
{
    public class HangHoaViewModel
    {
        public int MaHh { get; set; }
        public string SKU { get; set; }
        public string TenHh { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        public double GiaBan => DonGia * (100 - GiamGia) / 100.0;
    }
}
