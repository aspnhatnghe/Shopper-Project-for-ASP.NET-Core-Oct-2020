using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopperProject.Data;
using ShopperProject.Models;
using System.Linq;

namespace ShopperProject.Controllers
{
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
            var data = _context.HangHoas.ToList();

            var dsHangHoa = _mapper.Map<HangHoaViewModel>(data);

            return View(dsHangHoa);
        }
    }
}