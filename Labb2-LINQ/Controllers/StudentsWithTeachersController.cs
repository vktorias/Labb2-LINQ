using Labb2_LINQ.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb2_LINQ.Controllers
{
    public class StudentsWithTeachersController : Controller
    {
            private readonly LinqSchoolDbContext _context;

            public StudentsWithTeachersController(LinqSchoolDbContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                return View();
            }

            public IActionResult GetStudentsWithTeachers()
            {
                // Hämta alla elever med deras lärare
                var studentsWithTeacher = _context.Students
                    .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                     .ThenInclude(tc => tc.TeacherCourses)
                      .ThenInclude(t => t.Teacher)
          .ToList();

                // Returnera en vy med eleverna och deras lärare
                return View(studentsWithTeacher);
            }

        }
    }

