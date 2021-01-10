
using Microsoft.AspNetCore.Http;
using System.IO;

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
    }
}
