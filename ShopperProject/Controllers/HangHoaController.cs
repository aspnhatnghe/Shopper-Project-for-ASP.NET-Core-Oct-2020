using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PagedList.Core;
using ShopperProject.Data;
using ShopperProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopperProject.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly ShopperDbContext _context;
        private readonly IMapper _mapper;
        private readonly int SoSanPhamMoiTrang;

        public HangHoaController(ShopperDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            SoSanPhamMoiTrang = int.Parse(configuration["AppSettings:MaxItemCount"].ToString());
        }

        public IActionResult Index(int? loai, int page = 1)
        {
            var data = _context.HangHoas.AsQueryable();

            if(loai.HasValue)
            {
                data = data.Where(hh => hh.MaLoai == loai);
            }

            PagedList<HangHoa> model = new PagedList<HangHoa>(data, page, SoSanPhamMoiTrang);

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var data = _context.HangHoas.SingleOrDefault(hh => hh.MaHh == id);
            if(data == null)
            {
                return RedirectToAction("Index");
            }

            return View(data);
        }
    }
}