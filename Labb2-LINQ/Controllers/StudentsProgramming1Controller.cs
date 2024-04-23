using Labb2_LINQ.Data;
using Microsoft.AspNetCore.Mvc;

namespace Labb2_LINQ.Controllers
{
    public class StudentsProgramming1Controller : Controller
    {
        private readonly LinqSchoolDbContext _context;

        public StudentsProgramming1Controller(LinqSchoolDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetStudentsProgramming1()
        {
            // Hämta alla elever som läser "Programming 1" och deras lärare
            var studentsAndTeachers = _context.StudentCourses
                .Where(sc => sc.Course.CourseName == "Programming 1")
                .Select(sc => new
                {
                    Student = sc.Student,
                    Teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == sc.Student.TeacherId)
                })
                .ToList();

            // Skapa en lista för att hålla elever och deras lärare
            var studentsAndTheirTeachers = new List<dynamic>();

            // Loopa igenom alla elever och deras lärare
            foreach (var item in studentsAndTeachers)
            {
                studentsAndTheirTeachers.Add(new
                {
                    StudentName = $"{item.Student.StudentFirstName} {item.Student.StudentLastName}",
                    TeacherName = item.Teacher != null ? $"{item.Teacher.TeacherFirstName} {item.Teacher.TeacherLastName}" : "No teacher assigned"
                });
            }

            return View(studentsAndTheirTeachers);
        }

    }
}
