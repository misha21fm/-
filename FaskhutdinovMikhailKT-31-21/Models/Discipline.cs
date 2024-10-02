﻿namespace FaskhutdinovMikhailKT_31_21.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string Name { get; set; }

        // Преподаватели, ведущие данную дисциплину
        public ICollection<TeacherDiscipline> TeacherDisciplines { get; set; }
    }
}
