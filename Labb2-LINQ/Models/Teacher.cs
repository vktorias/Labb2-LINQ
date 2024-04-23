using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labb2_LINQ.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string TeacherFirstName { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string TeacherLastName { get; set; }

        public ICollection<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>();
    }
}

