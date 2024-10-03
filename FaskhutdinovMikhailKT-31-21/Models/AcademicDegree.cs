namespace FaskhutdinovMikhailKT_31_21.Models
{
    public class AcademicDegree
    {
        public int AcademicDegreeId { get; set; }
        public string Title { get; set; }

        // Список преподавателей с этой степенью
        public ICollection<Teacher>? Teachers { get; set; }
    }
}
