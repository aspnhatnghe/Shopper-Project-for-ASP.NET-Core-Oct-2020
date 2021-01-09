using System;
using System.ComponentModel.DataAnnotations;

namespace ShopperProject.Areas.Admin.Models
{
    public class KiemTraLonHonKhongAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var giaTri = (double)value;
            if (giaTri > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Không được nhỏ hơn hoặc bằng 0");
        }
    }
}