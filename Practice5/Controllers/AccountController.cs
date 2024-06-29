using Microsoft.AspNetCore.Mvc;
using Practice6.Models;
using Microsoft.EntityFrameworkCore;

namespace Practice6.Controllers
{
    public class AccountController : Controller
    {
        private readonly ModelContext _context;

        public AccountController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet("Account/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Account/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = await _context.Students
                    .FirstOrDefaultAsync(s => s.Email == model.Email && s.Password == model.Password);

                if (student != null)
                {
                    HttpContext.Session.SetInt32("StudentId", student.Id);

                    var route = "Achievements/" + student.Id;

                    return RedirectToAction("1", "Achievements");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("StudentId");

            return RedirectToAction("Login", "Account");
        }
    }

}
