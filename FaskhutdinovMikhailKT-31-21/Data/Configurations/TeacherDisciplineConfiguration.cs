using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class TeacherDisciplineConfiguration : IEntityTypeConfiguration<TeacherDiscipline>
    {
        private const string TableName = "cd_teacher_discipline";

        public void Configure(EntityTypeBuilder<TeacherDiscipline> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => new {e.DisciplineId, e.TeacherId})
                .HasName($"pk_{TableName}_teacher_discipline_id");


            builder.Property(e => e.TeacherId)
                .HasColumnName("f_teacher_id")
                .HasComment("Идентификатор преподавателя");

            builder.Property(e => e.DisciplineId)
                .HasColumnName("f_discipline_id")
                .HasComment("Идентификатор дисциплины");

            builder.Property(e => e.WorkloadHours)
                .HasColumnName("n_workload_hours")
                .HasColumnType("int")
                .HasComment("Рабочие часы");

            builder.ToTable(TableName)
                .HasOne(e => e.Discipline)
                .WithMany()
                .HasForeignKey(e => e.DisciplineId)
                .HasConstraintName("fk_f_discipline_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasOne(e => e.Teacher)
                .WithMany()
                .HasForeignKey(e => e.TeacherId)
                .HasConstraintName("fk_f_teacher_id")
                .OnDelete(DeleteBehavior.Cascade);


            //Указать индексы для внешних ключей
            builder.ToTable(TableName)
                .HasIndex(e => e.TeacherId, "idx_teacher_id");

            builder.ToTable(TableName)
                .HasIndex(e => e.DisciplineId, "idx_discipline_id");
        }
    }
}
