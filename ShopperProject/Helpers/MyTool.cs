
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;

namespace ShopperProject.Helpers
{
    public class MyTool
    {
        public static string UploadImage(IFormFile myfile, params string[] path)
        {
            //Muốn upload vào TM /wwwroot/Hinh/HangHoa
            // MyTool.UploadImage(file, "wwwroot", "Hinh", "HangHoa")
            try
            {
                var fullPath = Directory.GetCurrentDirectory();
                foreach (var item in path)
                {
                    fullPath = Path.Combine(fullPath, item);
                }
                fullPath = Path.Combine(fullPath, myfile.FileName);
                using (var newFile = new FileStream(fullPath, FileMode.Create))
                {
                    myfile.CopyTo(newFile);
                }
                return myfile.FileName;
            }
            catch { return string.Empty; }
        }

        public static string GetRandom(int length = 5)
        {
            var pattern = @"1234567890qazwsxedcrfvtgbyhn@#$%";
            var rd = new Random();
            var sb = new StringBuilder();
            for (int i = 0; i < length; i++)
                sb.Append(pattern[rd.Next(0, pattern.Length)]);

            return sb.ToString();
        }
    }
}
