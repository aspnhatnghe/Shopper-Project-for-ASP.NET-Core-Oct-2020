using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopperProject.Data;

namespace ShopperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HangHoaController : Controller
    {
        private readonly ShopperDbContext _context;

        public HangHoaController(ShopperDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.HangHoas;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}