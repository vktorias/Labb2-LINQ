using Labb2_LINQ.Data;
using Labb2_LINQ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Labb2_LINQ.Controllers
{
    public class TeachersProgramming1Controller : Controller
    {
        private readonly LinqSchoolDbContext _context;

        public TeachersProgramming1Controller(LinqSchoolDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.ToList() ?? new List<Course>();
            ViewData["Courses"] = courses;
            return View("GetTeachersForCourse", courses);
        }

        public async Task<IActionResult> GetTeachersForCourse(int courseId)
        {
            var courses = _context.Courses.ToList();
            ViewData["Courses"] = courses;

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
            if (course != null)
            {
                ViewBag.SelectedCourseId = course.CourseId;
                ViewBag.SelectedCourseName = course.CourseName;

                var teachers = _context.TeacherCourses
                    .Where(tc => tc.CourseId == courseId)
                    .Join(_context.Teachers,
                    tc => tc.TeacherId,
                    t => t.TeacherId,
                    (tc, t) => t)
                    .Distinct()
                    .ToList();

                ViewData["HasTeachers"] = teachers.Any();
                return View(teachers);
            }
            else
            {
                ViewData["HasTeachers"] = false;
                return View(new List<Teacher>());
            }
        }

    }
}
