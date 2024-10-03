namespace FaskhutdinovMikhailKT_31_21.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        // Связь с кафедрой
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        // Ученая степень
        public int? AcademicDegreeId { get; set; }
        public AcademicDegree? AcademicDegree { get; set; }

        // Должность
        public int? PositionId { get; set; }
        public Position? Position { get; set; }

        // Список дисциплин, которые ведет преподаватель
        public ICollection<TeacherDiscipline>? TeacherDisciplines { get; set; }
    }
}
