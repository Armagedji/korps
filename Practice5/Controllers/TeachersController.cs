using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice6.Models;
using YourNamespace.Filters;

namespace Practice6.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ModelContext _context;

        public TeachersController(ModelContext context)
        {
            _context = context;
        }

        // GET: Teachers
        [SessionAuthorize]
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Teachers.Include(t => t.Department).Include(t => t.Discipline);
            return View(await modelContext.ToListAsync());
        }
    }
}
