using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopperProject.Areas.Admin.Models;
using ShopperProject.Data;

namespace ShopperProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HangHoaController : Controller
    {
        private readonly ShopperDbContext _context;
        private readonly IMapper _mapper;

        public HangHoaController(ShopperDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var data = _context.HangHoas;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Loai = new SelectList(_context.Loais, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Loai = new SelectList(_context.Loais, "MaLoai", "TenLoai");
                return View();
            }

            try
            {
                var hangHoa = _mapper.Map<HangHoa>(model);

                //Xử lý cho SKU
                var hangHoaCuoiCung = _context.HangHoas.OrderByDescending(p => p.SKU).FirstOrDefault();
                var stt = 1;
                if (hangHoaCuoiCung != null)
                {
                    stt = int.Parse(hangHoaCuoiCung.SKU.Substring(2)) + 1;
                }
                hangHoa.SKU = "HH" + stt.ToString("00000");

                _context.Add(hangHoa);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Loai = new SelectList(_context.Loais, "MaLoai", "TenLoai");
                return View();
            }
        }
    }
}