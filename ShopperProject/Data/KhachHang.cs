using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperProject.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public int MaNd { get; set; }
        [MaxLength(100)]
        [Required]
        public string HoTen { get; set; }
        [MaxLength(20)]
        [Required]
        public string SoDienThoai { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string DiaChi { get; set; }
        public bool DangHoatDong { get; set; }
        [MaxLength(10)]
        [Required]
        public string MaNgauNhien { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
    }

    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }

    [Table("VaiTro")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(50)]
        [Required]
        public string RoleName { get; set; }
        public bool IsSystem { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
    }
}
