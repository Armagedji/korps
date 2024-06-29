using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice6.Models;
using YourNamespace.Filters;

namespace Practice6.Controllers
{
    public class PerformancesController : Controller
    {
        private readonly ModelContext _context;

        public PerformancesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Performances/Details/5
        [SessionAuthorize]
        [HttpGet("Performances/{student_id}")]
        public async Task<IActionResult> Index(int student_id, int semester, string subjectName, int grade)
        {
            var performances = _context.Performances.Include(p => p.Student).Include(p=>p.Discipline).Where(p=>p.StudentId == student_id).AsQueryable();

            if (semester != 0)
            {
                performances = performances.Where(p => (p.Semester) == semester);
            }

            if (!string.IsNullOrEmpty(subjectName))
            {
                performances = performances.Where(p => p.Discipline.Name.Contains(subjectName));
            }

            if (grade != 0)
            {
                performances = performances.Where(p => p.Score == (grade));
            }
            var student = await _context.Students.FindAsync(student_id);
            ViewBag.Student = student;
            return View(await performances.ToListAsync());
        }
    }
}
