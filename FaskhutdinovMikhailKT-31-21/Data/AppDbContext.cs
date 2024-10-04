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

            /*// Данные для таблиц
            modelBuilder.Entity<AcademicDegree>().HasData(
                new AcademicDegree { AcademicDegreeId = 1, Title = "Кандидат наук" },
                new AcademicDegree { AcademicDegreeId = 2, Title = "Доктор наук" }
            );

            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = 1, Title = "Преподаватель" },
                new Position { PositionId = 2, Title = "Старший преподаватель" },
                new Position { PositionId = 3, Title = "Доцент" },
                new Position { PositionId = 4, Title = "Профессор" }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "Кафедра математики", HeadId = 1 },
                new Department { DepartmentId = 2, Name = "Кафедра физики", HeadId = 3 },
                new Department { DepartmentId = 3, Name = "Кафедра информатики", HeadId = 4 },
                new Department { DepartmentId = 4, Name = "Кафедра химии", HeadId = 6 },
                new Department { DepartmentId = 5, Name = "Кафедра биологии", HeadId = 8 }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, FirstName = "Иван", LastName = "Иванов", Patronymic = "Иванович", DepartmentId = 1, AcademicDegreeId = 1, PositionId = 2 },
                new Teacher { TeacherId = 2, FirstName = "Петр", LastName = "Петров", Patronymic = "Петрович", DepartmentId = 1, AcademicDegreeId = 2, PositionId = 4 },
                new Teacher { TeacherId = 3, FirstName = "Сергей", LastName = "Сергеев", Patronymic = "Сергеевич", DepartmentId = 2, AcademicDegreeId = 1, PositionId = 3 },
                new Teacher { TeacherId = 4, FirstName = "Андрей", LastName = "Андреев", Patronymic = "Андреевич", DepartmentId = 3, AcademicDegreeId = 2, PositionId = 4 },
                new Teacher { TeacherId = 5, FirstName = "Николай", LastName = "Николаев", Patronymic = "Николаевич", DepartmentId = 2, AcademicDegreeId = 1, PositionId = 1 },
                new Teacher { TeacherId = 6, FirstName = "Ольга", LastName = "Ольгина", Patronymic = "Ольговна", DepartmentId = 4, AcademicDegreeId = 1, PositionId = 2 },
                new Teacher { TeacherId = 7, FirstName = "Мария", LastName = "Мариева", Patronymic = "Мариевна", DepartmentId = 5, AcademicDegreeId = 2, PositionId = 3 },
                new Teacher { TeacherId = 8, FirstName = "Дмитрий", LastName = "Дмитриев", Patronymic = "Дмитриевич", DepartmentId = 3, AcademicDegreeId = 2, PositionId = 4 },
                new Teacher { TeacherId = 9, FirstName = "Елена", LastName = "Еленова", Patronymic = "Еленовна", DepartmentId = 4, AcademicDegreeId = 1, PositionId = 1 },
                new Teacher { TeacherId = 10, FirstName = "Анна", LastName = "Антонова", Patronymic = "Антоновна", DepartmentId = 5, AcademicDegreeId = 2, PositionId = 3 }
            );

            modelBuilder.Entity<Discipline>().HasData(
                new Discipline { DisciplineId = 1, Name = "Математический анализ" },
                new Discipline { DisciplineId = 2, Name = "Физика твердого тела" },
                new Discipline { DisciplineId = 3, Name = "Программирование на C#" },
                new Discipline { DisciplineId = 4, Name = "Органическая химия" },
                new Discipline { DisciplineId = 5, Name = "Генетика" },
                new Discipline { DisciplineId = 6, Name = "Функциональный анализ" },
                new Discipline { DisciplineId = 7, Name = "Теоретическая физика" },
                new Discipline { DisciplineId = 8, Name = "Алгоритмы и структуры данных" },
                new Discipline { DisciplineId = 9, Name = "Физическая химия" },
                new Discipline { DisciplineId = 10, Name = "Биохимия" }
            );

            modelBuilder.Entity<TeacherDiscipline>().HasData(
                new TeacherDiscipline { TeacherId = 1, DisciplineId = 1, WorkloadHours = 30 },
                new TeacherDiscipline { TeacherId = 2, DisciplineId = 2, WorkloadHours = 25 },
                new TeacherDiscipline { TeacherId = 3, DisciplineId = 2, WorkloadHours = 40 },
                new TeacherDiscipline { TeacherId = 4, DisciplineId = 3, WorkloadHours = 50 },
                new TeacherDiscipline { TeacherId = 5, DisciplineId = 1, WorkloadHours = 20 },
                new TeacherDiscipline { TeacherId = 6, DisciplineId = 4, WorkloadHours = 35 },
                new TeacherDiscipline { TeacherId = 7, DisciplineId = 5, WorkloadHours = 40 },
                new TeacherDiscipline { TeacherId = 8, DisciplineId = 8, WorkloadHours = 50 },
                new TeacherDiscipline { TeacherId = 9, DisciplineId = 9, WorkloadHours = 20 },
                new TeacherDiscipline { TeacherId = 10, DisciplineId = 10, WorkloadHours = 35 }
            );*/

            base.OnModelCreating(modelBuilder);
        }

    }
}
