using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labb2_LINQ.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        public string CourseName { get; set; }

        public ICollection<TeacherCourse> TeacherCourses { get; set; } = [];

        public ICollection<StudentCourse> StudentCourses { get; set; } = [];
    }
}

