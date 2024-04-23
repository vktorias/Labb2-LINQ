using System.ComponentModel.DataAnnotations;

namespace Labb2_LINQ.Models
{
    //Kopplingstabell
    public class TeacherCourse
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
