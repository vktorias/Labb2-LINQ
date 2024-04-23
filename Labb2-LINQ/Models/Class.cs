using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_LINQ.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 10 characters")]
        public string ClassName { get; set; }
    }
}
