
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopperProject.Data
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public int? MaLoaiCha { get; set; }
        [ForeignKey("MaLoaiCha")]
        public Loai LoaiCha { get; set; }
    }
}
