
using System.ComponentModel.DataAnnotations;

namespace ShopperProject.Models
{
    public class RegisteUser
    {
        [MaxLength(100)]
        [Required]
        [Display(Name ="Họ tên")]
        public string HoTen { get; set; }

        [MaxLength(20)]
        [Required]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [MaxLength(100)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
    }
}
