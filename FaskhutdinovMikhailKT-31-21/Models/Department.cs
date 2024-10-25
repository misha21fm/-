using Microsoft.Identity.Client;

namespace FaskhutdinovMikhailKT_31_21.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        // Связь с заведующим кафедры
        public int? HeadId { get; set; }
        public Teacher? Head { get; set; }

        public bool IsValidCreateDate()
        {
            return (CreateDate.Year > 1500 && CreateDate.Year < 2100); 
        }
    }
}
