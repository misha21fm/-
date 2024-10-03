using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {

        private const string TableName = "Teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => e.TeacherId);

            // Задается автогенерация для PK
            builder.Property(e => e.TeacherId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.TeacherId)
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор преподавателя");

            builder.Property(e => e.FirstName)
                .HasColumnName("firstname")
                .HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(e => e.LastName)
               .HasColumnName("lastname")
               .HasMaxLength(100)
               .HasComment("Имя преподавателя");

            builder.Property(e => e.Patronymic)
               .HasColumnName("patronymic")
               .HasMaxLength(100)
               .HasComment("Отчество преподавателя");

            builder.Property(e => e.DepartmentId)
                .HasColumnName("department_id")
                .IsRequired(false)
                .HasComment("Идентификатор кафедры");

            builder.Property(e => e.AcademicDegreeId)
               .HasColumnName("academic_degree_id")
               .HasComment("Идентификатор ученой степени");

            builder.Property(e => e.PositionId)
               .HasColumnName("position_id")
               .HasComment("Идентификатор должности");

            // Указание связей
            builder.ToTable(TableName)
                .HasMany(e => e.TeacherDisciplines)
                .WithOne(e => e.Teacher)
                .HasForeignKey(e => e.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasOne(e => e.Department)
                .WithMany(e => e.Teachers)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasOne(e => e.AcademicDegree)
                .WithMany(e => e.Teachers)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasOne(e => e.Position)
                .WithMany(e => e.Teachers)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasIndex(e => e.DepartmentId, "index_department_id");
            builder.ToTable(TableName)
                .HasIndex(e => e.AcademicDegreeId, "index_academic_degree_id");
            builder.ToTable(TableName)
                .HasIndex(e => e.PositionId, "index_position_id");

        }

    }
}
