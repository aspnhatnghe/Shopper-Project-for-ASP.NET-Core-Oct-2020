using Microsoft.AspNetCore.Mvc;
using ShopperProject.Data;

namespace ShopperProject.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly ShopperDbContext _context;

        public HangHoaController(ShopperDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}