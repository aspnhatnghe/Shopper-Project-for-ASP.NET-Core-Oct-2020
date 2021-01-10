using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperProject.Areas.Admin.Models
{
    public class HangHoaVM
    {
        [Key]
        [Display(Name = "Mã hàng hóa")]
        public int MaHh { get; set; }
        [MaxLength(150)]
        [Required]
        [Display(Name = "Tên hàng hóa")]
        public string TenHh { get; set; }

        [MaxLength(150)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }

        [KiemTraLonHonKhong]
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Số lượng tồn")]
        public int SoLuongTon { get; set; }

        public byte? GiamGia { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name ="Loại")]
        public int MaLoai { get; set; }        
    }
}
