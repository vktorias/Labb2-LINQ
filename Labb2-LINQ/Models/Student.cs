using System.ComponentModel.DataAnnotations;

namespace Labb2_LINQ.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string StudentFirstName { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string StudentLastName { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; } 
        public ICollection<StudentCourse> StudentCourses { get; set; } = [];

    }
}
