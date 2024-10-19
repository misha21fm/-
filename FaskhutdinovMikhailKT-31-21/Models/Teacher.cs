using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public Department? Department { get; set; }

        // Ученая степень
        public int? AcademicDegreeId { get; set; }

        [JsonIgnore]
        public AcademicDegree? AcademicDegree { get; set; }

        // Должность
        public int? PositionId { get; set; }

        [JsonIgnore]
        public Position? Position { get; set; }

    }
}
