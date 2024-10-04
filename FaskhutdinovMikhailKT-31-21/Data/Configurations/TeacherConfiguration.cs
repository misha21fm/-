using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {

        private const string TableName = "cd_teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => e.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            // Задается автогенерация для PK
            builder.Property(e => e.TeacherId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.TeacherId)
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор преподавателя");

            builder.Property(e => e.FirstName)
                .HasColumnName("c_firstname")
                .HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(e => e.LastName)
               .HasColumnName("c_lastname")
               .HasMaxLength(100)
               .HasComment("Имя преподавателя");

            builder.Property(e => e.Patronymic)
               .HasColumnName("c_patronymic")
               .HasMaxLength(100)
               .HasComment("Отчество преподавателя");

            builder.Property(e => e.DepartmentId)
                .HasColumnName("f_department_id")
                .IsRequired(false)
                .HasComment("Идентификатор кафедры");

            builder.Property(e => e.AcademicDegreeId)
               .HasColumnName("f_academic_degree_id")
               .IsRequired(false)
               .HasComment("Идентификатор ученой степени");

            builder.Property(e => e.PositionId)
               .HasColumnName("f_position_id")
               .IsRequired(false)
               .HasComment("Идентификатор должности");

            // Указание связей
            
            builder.ToTable(TableName)
                .HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId)
//                .IsRequired(false)
                .HasConstraintName("fk_f_department_id")
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasOne(e => e.AcademicDegree)
                .WithMany()
                .HasForeignKey(e => e.AcademicDegreeId)
//                .IsRequired(false)
                .HasConstraintName("fk_f_academic_degree_id")
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.PositionId)
//                .IsRequired(false)
                .HasConstraintName("fk_f_position_id")
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasIndex(e => e.DepartmentId, "idx_department_id");
            builder.ToTable(TableName)
                .HasIndex(e => e.AcademicDegreeId, "idx_academic_degree_id");
            builder.ToTable(TableName)
                .HasIndex(e => e.PositionId, "idx_position_id");

        }

    }
}
