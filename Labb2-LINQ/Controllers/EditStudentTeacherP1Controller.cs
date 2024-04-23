using Labb2_LINQ.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EditStudentTeacherP1Controller : Controller
{
    private readonly LinqSchoolDbContext _context;

    public EditStudentTeacherP1Controller(LinqSchoolDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult EditStudentTeacher()
    {
        var programming1Course = _context.Courses.FirstOrDefault(c => c.CourseName == "Programming 1");
        if (programming1Course == null)
        {
            // Hantera fel om kursen inte finns
            return NotFound("Programming 1 not found");
        }

        var students = _context.Students
            .Where(s => s.StudentCourses.Any(sc => sc.CourseId == programming1Course.CourseId))
            .ToList();

        // Skriv ut antalet elever som hämtades
        Console.WriteLine($"Antal elever: {students.Count}");

        var teachers = _context.Teachers
            .Where(t => t.TeacherCourses.Any(tc => tc.CourseId == programming1Course.CourseId))
            .ToList();

        // Skriv ut antalet lärare som hämtades
        Console.WriteLine($"Antal lärare: {teachers.Count}");

        ViewBag.Students = students;
        ViewBag.Teachers = teachers;

        return View();
    }

    [HttpPost]
    public IActionResult UpdateTeacher(int studentId, int teacherId)
    {
        var student = _context.Students.FirstOrDefault(s => s.StudentId == studentId);
        if (student != null)
        {
            TempData["SelectedStudentId"] = studentId;
            TempData["SelectedTeacherId"] = teacherId;

            // Kolla om den valda läraren är annorlunda än den nuvarande
            if (student.TeacherId != teacherId)
            {
                student.TeacherId = teacherId;
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Teacher was updated successfully!";
            }
            else
            {
                TempData["SuccessMessage"] = "Teacher remains the same. No update was needed.";
            }
        }
        return RedirectToAction("EditStudentTeacher");
    }
}
