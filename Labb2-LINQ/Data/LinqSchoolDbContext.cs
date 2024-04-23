using Labb2_LINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb2_LINQ.Data
{
    public class LinqSchoolDbContext : DbContext
    {
        public LinqSchoolDbContext(DbContextOptions<LinqSchoolDbContext> options) : base(options)
        {

        }
        
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; } 
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TeacherCourse>()
                .HasKey(tc => new { tc.TeacherId, tc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            SeedData(modelBuilder);
        }

        //Metod för att lägga in data till databasen med EF
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, TeacherFirstName = "Reidar", TeacherLastName = "Nilsen"},
                new Teacher { TeacherId = 2, TeacherFirstName = "Tobias", TeacherLastName = "Landén"},
                new Teacher { TeacherId = 3, TeacherFirstName = "Aldor", TeacherLastName = "Besher"}
                );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "Programming 1" },
                new Course { CourseId = 2, CourseName = "Programming 2" },
                new Course { CourseId = 3, CourseName = "English" },
                new Course { CourseId = 4, CourseName = "Social Sciences" },
                new Course { CourseId = 5, CourseName = "Economics" }
                );
            modelBuilder.Entity<TeacherCourse>().HasData(
                new TeacherCourse { TeacherId = 1, CourseId = 1 },
                new TeacherCourse { TeacherId = 3, CourseId = 2 },
                new TeacherCourse { TeacherId = 1, CourseId = 3 },
                new TeacherCourse { TeacherId = 3, CourseId = 4 },
                new TeacherCourse { TeacherId = 2, CourseId = 5 },
                new TeacherCourse { TeacherId = 2, CourseId = 1 },
                new TeacherCourse { TeacherId = 1, CourseId = 4 }
                );
            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse { StudentId = 1, CourseId = 1 },
                new StudentCourse { StudentId = 2, CourseId = 2 },
                new StudentCourse { StudentId = 3, CourseId = 3 },
                new StudentCourse { StudentId = 4, CourseId = 4 },
                new StudentCourse { StudentId = 5, CourseId = 5 },
                new StudentCourse { StudentId = 6, CourseId = 4 },
                new StudentCourse { StudentId = 7, CourseId = 1 },
                new StudentCourse { StudentId = 8, CourseId = 2 },
                new StudentCourse { StudentId = 9, CourseId = 3 },
                new StudentCourse { StudentId = 10, CourseId = 1 },
                new StudentCourse { StudentId = 11, CourseId = 1 },
                new StudentCourse { StudentId = 12, CourseId = 1 },
                new StudentCourse { StudentId = 13, CourseId = 1 },
                new StudentCourse { StudentId = 14, CourseId = 1 }
            );
            modelBuilder.Entity<Class>().HasData(
                new Class { ClassId = 1, ClassName = "1A" },
                new Class { ClassId = 2, ClassName = "1B" },
                new Class { ClassId = 3, ClassName = "2A" },    
                new Class { ClassId = 4, ClassName = "2B" }
                );
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentFirstName = "Ellen", StudentLastName = "Berg", ClassId = 1, TeacherId = 1},
                new Student { StudentId = 2, StudentFirstName = "Erik", StudentLastName = "Karlsson", ClassId = 2},
                new Student { StudentId = 3, StudentFirstName = "Karolin", StudentLastName = "Jonsson", ClassId = 3},
                new Student { StudentId = 4, StudentFirstName = "Jonas", StudentLastName = "Ytterbom", ClassId = 4},
                new Student { StudentId = 5, StudentFirstName = "Patricia", StudentLastName = "Larsson", ClassId = 4},
                new Student { StudentId = 6, StudentFirstName = "Rickard", StudentLastName = "Svensson", ClassId = 2 },
                new Student { StudentId = 7, StudentFirstName = "Klara", StudentLastName = "Hedman", ClassId = 2, TeacherId = 2},
                new Student { StudentId = 8, StudentFirstName = "Hampus", StudentLastName = "Lagergren", ClassId = 3 },
                new Student { StudentId = 9, StudentFirstName = "Lisa", StudentLastName = "Löf", ClassId = 2 },
                new Student { StudentId = 10, StudentFirstName = "Kalle", StudentLastName = "Broman", ClassId = 1, TeacherId = 2 },
                new Student { StudentId = 11, StudentFirstName = "Erik", StudentLastName = "Bergman", ClassId = 2, TeacherId = 1 },
                new Student { StudentId = 12, StudentFirstName = "Johan", StudentLastName = "Larsson", ClassId = 2, TeacherId = 2 },
                new Student { StudentId = 13, StudentFirstName = "Johanna", StudentLastName = "Eriksson", ClassId = 4, TeacherId = 1 },
                new Student { StudentId = 14, StudentFirstName = "Gunilla", StudentLastName = "Olsson", ClassId = 3, TeacherId = 1 }
                );
        }
    }
}
