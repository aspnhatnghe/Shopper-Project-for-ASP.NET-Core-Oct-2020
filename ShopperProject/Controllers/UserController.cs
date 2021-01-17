using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopperProject.Data;
using ShopperProject.Helpers;
using ShopperProject.Models;
using System.Linq;
using ShopperProject.Helpers;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

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

        public IActionResult Login(string ReturnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string ReturnUrl = null)
        {
            var thongBaoLoi = string.Empty;
            var userLogin = _context.Users.SingleOrDefault(p => p.Email == loginVM.Email && p.MatKhau == loginVM.MatKhau.ToSHA512Hash(p.MaNgauNhien));

            if(userLogin == null)
            {
                thongBaoLoi = "Sai thông tin đăng nhập";
                return View();
            }

            var userClaims = new List<Claim> { 
                new Claim(ClaimTypes.Email, userLogin.Email),
                new Claim(ClaimTypes.Name, userLogin.HoTen),
                new Claim("MaNguoiDung", userLogin.MaNd.ToString())
            };

            var roles = _context.UserRoles.Where(p => p.UserId == userLogin.MaNd)
                .Select(p => new { 
                    RoleId = p.RoleId,
                    RoleName = p.Role.RoleName
                });

            foreach(var role in roles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims, "login");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);

            if (Url.IsLocalUrl(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction("Profile");
        }
    }
}