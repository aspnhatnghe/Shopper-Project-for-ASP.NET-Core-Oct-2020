using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopperProject.Data;
using ShopperProject.Helpers;
using ShopperProject.Models;

namespace ShopperProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopperDbContext _context;

        public CartController(ShopperDbContext context)
        {
            _context = context;
        }

        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }

        public IActionResult Index()
        {
            return View(Carts);
        }


        public IActionResult AddToCart(int MaHh, int SoLuong = 1)
        {
            var gioHang = Carts;
            var item = gioHang.SingleOrDefault(p => p.MaHh == MaHh);
            if(item != null)//có rồi
            {
                item.SoLuong += SoLuong;
            }
            else
            {
                var hangHoa = _context.HangHoas.SingleOrDefault(p => p.MaHh == MaHh);
                item = new CartItem { 
                    MaHh = hangHoa.MaHh,
                    TenHh = hangHoa.TenHh,
                    DonGia = hangHoa.GiaBan,
                    Hinh = hangHoa.Hinh,
                    SoLuong = SoLuong
                };
                gioHang.Add(item);
            }
            HttpContext.Session.Set("GioHang", gioHang);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveCartItem(int MaHh)
        {
            var gioHang = Carts;
            var item = gioHang.SingleOrDefault(p => p.MaHh == MaHh);
            if(item != null)
            {
                gioHang.Remove(item);
            }
            HttpContext.Session.Set("GioHang", gioHang);
            return RedirectToAction("Index");
        }
    }
}