namespace FaskhutdinovMikhailKT_31_21.Filters
{
    public class DepartmentFilter
    {
        public string? DepartmentName { get; set; }
        public int? CreationYear { get; set; } 
        public int? TeachersCountMin { get; set; }
        public int? TeachersCountMax { get; set; }
    }
}