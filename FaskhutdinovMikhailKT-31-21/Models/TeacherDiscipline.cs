namespace FaskhutdinovMikhailKT_31_21.Models
{
    public class TeacherDiscipline
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        public int WorkloadHours { get; set; }
    }
}
