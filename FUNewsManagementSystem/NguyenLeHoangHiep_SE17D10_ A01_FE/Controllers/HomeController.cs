using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NguyenLeHoangHiep_SE17D10__A01_FE.Models;

namespace NguyenLeHoangHiep_SE17D10__A01_FE.Controllers
{
   
        public class HomeController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }

            public IActionResult Admin()
            {
                if (HttpContext.Session.GetString("UserRole") != "Admin") return RedirectToAction("Login", "Auth");
                return View();
            }

            public IActionResult Staff()
            {
                if (HttpContext.Session.GetString("UserRole") != "Staff") return RedirectToAction("Login", "Auth");
                return View();
            }
        }
    }

