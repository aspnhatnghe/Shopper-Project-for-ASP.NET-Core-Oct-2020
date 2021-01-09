using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopperProject.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public int SoLuongTon { get; set; }
        public byte? GiamGia { get; set; }
        public string MoTa { get; set; }
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

    }
}
