
using System.ComponentModel.DataAnnotations;

namespace ShopperProject.Models
{
    public class LoginVM
    {
        [MaxLength(100)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}
