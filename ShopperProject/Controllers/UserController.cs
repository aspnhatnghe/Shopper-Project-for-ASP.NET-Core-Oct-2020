using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopperProject.Data;
using ShopperProject.Helpers;
using ShopperProject.Models;

namespace ShopperProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ShopperDbContext _context;
        private readonly IMapper _mapper;

        public UserController(ShopperDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUser model)
        {
            var ts = _context.Database.BeginTransaction();
            try
            {
                var customer = _mapper.Map<User>(model);
                customer.MaNgauNhien = MyTool.GetRandom();
                customer.MatKhau = model.MatKhau.ToSHA512Hash(customer.MaNgauNhien);

                _context.Add(customer);
                _context.SaveChanges();

                var userRole = new UserRole
                {
                    RoleId = RoleContants.Customer,
                    UserId = customer.MaNd
                };
                _context.Add(userRole);
                _context.SaveChanges();
                ts.Commit();
                return RedirectToAction("Login");
            }
            catch
            {
                ts.Rollback();
                return View();
            }
        }
    }
}