using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice6.Models;
using System.Diagnostics;

namespace Practice6.Controllers
{
    public class HomeController : Controller
    {
        ModelContext _context;

        public HomeController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? achievement_type)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }   
    }
}
