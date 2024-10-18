using FaskhutdinovMikhailKT_31_21.Data.Configurations;
using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace FaskhutdinovMikhailKT_31_21.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<TeacherDiscipline> TeacherDisciplines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherDisciplineConfiguration());

            // Seed for AcademicDegrees
            modelBuilder.Entity<AcademicDegree>().HasData(
                new AcademicDegree { AcademicDegreeId = 1, Title = "PhD in Computer Science" },
                new AcademicDegree { AcademicDegreeId = 2, Title = "PhD in Mathematics" },
                new AcademicDegree { AcademicDegreeId = 3, Title = "PhD in Physics" },
                new AcademicDegree { AcademicDegreeId = 4, Title = "Master of Science" },
                new AcademicDegree { AcademicDegreeId = 5, Title = "Master of Arts" },
                new AcademicDegree { AcademicDegreeId = 6, Title = "Bachelor of Science" },
                new AcademicDegree { AcademicDegreeId = 7, Title = "Bachelor of Arts" },
                new AcademicDegree { AcademicDegreeId = 8, Title = "Doctor of Engineering" },
                new AcademicDegree { AcademicDegreeId = 9, Title = "Doctor of Philosophy" },
                new AcademicDegree { AcademicDegreeId = 10, Title = "Doctor of Education" }
            );

            // Seed for Disciplines
            modelBuilder.Entity<Discipline>().HasData(
                new Discipline { DisciplineId = 1, Name = "Algorithms and Data Structures" },
                new Discipline { DisciplineId = 2, Name = "Linear Algebra" },
                new Discipline { DisciplineId = 3, Name = "Quantum Mechanics" },
                new Discipline { DisciplineId = 4, Name = "Organic Chemistry" },
                new Discipline { DisciplineId = 5, Name = "Genetics" },
                new Discipline { DisciplineId = 6, Name = "Circuit Design" },
                new Discipline { DisciplineId = 7, Name = "Thermodynamics" },
                new Discipline { DisciplineId = 8, Name = "Structural Analysis" },
                new Discipline { DisciplineId = 9, Name = "Microeconomics" },
                new Discipline { DisciplineId = 10, Name = "Cognitive Psychology" }
            );

            // Seed for TeacherDisciplines
            modelBuilder.Entity<TeacherDiscipline>().HasData(
                new TeacherDiscipline { TeacherId = 1, DisciplineId = 1, WorkloadHours = 100 },
                new TeacherDiscipline { TeacherId = 2, DisciplineId = 2, WorkloadHours = 80 },
                new TeacherDiscipline { TeacherId = 3, DisciplineId = 3, WorkloadHours = 90 },
                new TeacherDiscipline { TeacherId = 4, DisciplineId = 4, WorkloadHours = 110 },
                new TeacherDiscipline { TeacherId = 5, DisciplineId = 5, WorkloadHours = 95 },
                new TeacherDiscipline { TeacherId = 6, DisciplineId = 6, WorkloadHours = 70 },
                new TeacherDiscipline { TeacherId = 7, DisciplineId = 7, WorkloadHours = 85 },
                new TeacherDiscipline { TeacherId = 8, DisciplineId = 8, WorkloadHours = 120 },
                new TeacherDiscipline { TeacherId = 9, DisciplineId = 9, WorkloadHours = 75 },
                new TeacherDiscipline { TeacherId = 10, DisciplineId = 10, WorkloadHours = 65 }
            );

            // Seed for Positions
            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = 1, Title = "Professor" },
                new Position { PositionId = 2, Title = "Associate Professor" },
                new Position { PositionId = 3, Title = "Assistant Professor" },
                new Position { PositionId = 4, Title = "Lecturer" },
                new Position { PositionId = 5, Title = "Research Fellow" },
                new Position { PositionId = 6, Title = "Teaching Assistant" },
                new Position { PositionId = 7, Title = "Lab Instructor" },
                new Position { PositionId = 8, Title = "Department Chair" },
                new Position { PositionId = 9, Title = "Dean" },
                new Position { PositionId = 10, Title = "Academic Advisor" }
            );

            // Seed for Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "Computer Science", CreateDate = DateTime.Now, HeadId = null },
                new Department { DepartmentId = 2, Name = "Mathematics", CreateDate = DateTime.Now, HeadId = null },
                new Department { DepartmentId = 3, Name = "Physics", CreateDate = DateTime.Now, HeadId = null },
                new Department { DepartmentId = 4, Name = "Chemistry", CreateDate = DateTime.Now, HeadId = null },
                new Department { DepartmentId = 5, Name = "Biology", CreateDate = DateTime.Now, HeadId = null }
            );

            // Seed for Teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, FirstName = "John", LastName = "Smith", Patronymic = "A.", DepartmentId = 1, AcademicDegreeId = 1, PositionId = 1 },
                new Teacher { TeacherId = 2, FirstName = "Alice", LastName = "Johnson", Patronymic = "B.", DepartmentId = 2, AcademicDegreeId = 2, PositionId = 2 },
                new Teacher { TeacherId = 3, FirstName = "Robert", LastName = "Brown", Patronymic = "C.", DepartmentId = 3, AcademicDegreeId = 3, PositionId = 3 },
                new Teacher { TeacherId = 4, FirstName = "Mary", LastName = "Jones", Patronymic = "D.", DepartmentId = 4, AcademicDegreeId = 4, PositionId = 4 },
                new Teacher { TeacherId = 5, FirstName = "Michael", LastName = "Williams", Patronymic = "E.", DepartmentId = 4, AcademicDegreeId = 5, PositionId = 5 },
                new Teacher { TeacherId = 6, FirstName = "Patricia", LastName = "Garcia", Patronymic = "F.", DepartmentId = 5, AcademicDegreeId = 6, PositionId = 6 },
                new Teacher { TeacherId = 7, FirstName = "Linda", LastName = "Miller", Patronymic = "G.", DepartmentId = 4, AcademicDegreeId = 7, PositionId = 7 },
                new Teacher { TeacherId = 8, FirstName = "James", LastName = "Martinez", Patronymic = "H.", DepartmentId = 2, AcademicDegreeId = 8, PositionId = 8 },
                new Teacher { TeacherId = 9, FirstName = "Barbara", LastName = "Lopez", Patronymic = "I.", DepartmentId = 3, AcademicDegreeId = 9, PositionId = 9 },
                new Teacher { TeacherId = 10, FirstName = "David", LastName = "Wilson", Patronymic = "J.", DepartmentId = 2, AcademicDegreeId = 10, PositionId = 10 }
            );

            

            base.OnModelCreating(modelBuilder);
        }

    }
}
