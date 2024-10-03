namespace FaskhutdinovMikhailKT_31_21.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        // Связь с заведующим кафедры
        public int? HeadId { get; set; }
        public Teacher? Head { get; set; }

        // Список преподавателей, относящихся к кафедре
        public ICollection<Teacher>? Teachers { get; set; }
    }
}
