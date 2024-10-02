namespace FaskhutdinovMikhailKT_31_21.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Title { get; set; }

        // Список преподавателей, занимающих эту должность
        public ICollection<Teacher> Teachers { get; set; }
    }
}
