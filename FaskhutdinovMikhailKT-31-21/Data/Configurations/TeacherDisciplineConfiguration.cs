using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class TeacherDisciplineConfiguration : IEntityTypeConfiguration<TeacherDiscipline>
    {
        private const string TableName = "TeacherDiscipline";

        public void Configure(EntityTypeBuilder<TeacherDiscipline> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => new {e.DisciplineId, e.TeacherId})
                .HasName("pk_teacher_discipline");


            builder.Property(e => e.TeacherId)
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор преподавателя");

            builder.Property(e => e.DisciplineId)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор дисциплины");

            builder.Property(e => e.WorkloadHours)
                .HasColumnName("workload_hours")
                .HasColumnType("int")
                .HasComment("Рабочие часы");

            //Указание связей
            //builder.ToTable(TableName)
            //    .HasOne(e => e.Teacher)
            //    .WithMany(e => e.TeacherDisciplines)
            //    .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasOne(e => e.Discipline)
                .WithMany(e => e.TeacherDisciplines)
                .HasForeignKey(e => e.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
