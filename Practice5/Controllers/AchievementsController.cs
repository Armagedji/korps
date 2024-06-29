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
    public class AchievementsController : Controller
    {
        private readonly ModelContext _context;

        public AchievementsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Achievements
        [HttpGet("Achievements/{student_id}")]
        [SessionAuthorize]
        public async Task<IActionResult> Index(int? achievementTypeId, int student_id, DateOnly? startDate, DateOnly? endDate)
        {
            var achievements = _context.Achievements.Where(a=> a.StudentId == student_id).Include(a => a.Achievement_type).AsQueryable();

            if (achievementTypeId.HasValue)
            {
                achievements = achievements.Where(a => a.Achievement_typeId == achievementTypeId.Value);
            }

            if (startDate.HasValue)
            {
                achievements = achievements.Where(a => a.Achievment_date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                achievements = achievements.Where(a => a.Achievment_date <= endDate.Value);
            }

            var student = await _context.Students.FindAsync(student_id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            var achievementTypes = await _context.Achievement_types.ToListAsync();
            ViewBag.AchievementTypes = new SelectList(achievementTypes, "Id", "Name");
            ViewBag.Student = student;

            return View(await achievements.ToListAsync());
        }
    }
}