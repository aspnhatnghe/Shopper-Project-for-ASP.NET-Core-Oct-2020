using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopperProject.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public int MaHh { get; set; }

        [MaxLength(7)]
        public string SKU { get; set; }

        [MaxLength(150)]
        public string TenHh { get; set; }
        [MaxLength(150)]
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public int SoLuongTon { get; set; }
        public byte? GiamGia { get; set; }
        public string MoTa { get; set; }
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

        public double GiaBan => DonGia * (100 - GiamGia.Value) / 100.0;
    }
}
