using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopperProject.Areas.Admin.Models;
using ShopperProject.Data;
using ShopperProject.Helpers;

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
            var data = _context.HangHoas.Include(hh => hh.Loai);

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Loai = new SelectList(_context.Loais, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM model, IFormFile Hinh)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Loai = new SelectList(_context.Loais, "MaLoai", "TenLoai");
                return View();
            }

            try
            {
                var hangHoa = _mapper.Map<HangHoa>(model);

                hangHoa.Hinh = MyTool.UploadImage(Hinh, "wwwroot", "Hinh", "HangHoa");

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

        #region Edit HangHoa
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hangHoa = _context.HangHoas.SingleOrDefault(hh => hh.MaHh == id);
            if (hangHoa != null)
            {
                ViewBag.Loai = new SelectList(_context.Loais, "MaLoai", "TenLoai", hangHoa.MaLoai);
                return View(hangHoa);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(HangHoa hangHoa, IFormFile HinhEdit)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Loai = new SelectList(_context.Loais, "MaLoai", "TenLoai", hangHoa.MaLoai);
                return View();
            }

            if (HinhEdit != null)
            {
                var hinhFileName = MyTool.UploadImage(HinhEdit, "wwwroot", "Hinh", "HangHoa");
                if(!string.IsNullOrEmpty(hinhFileName))
                {
                    hangHoa.Hinh = hinhFileName;
                }
            }

            try
            {
                _context.Update(hangHoa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch {
                ViewBag.Loai = new SelectList(_context.Loais, "MaLoai", "TenLoai", hangHoa.MaLoai);
                return View();
            }
        }
        #endregion
    }
}