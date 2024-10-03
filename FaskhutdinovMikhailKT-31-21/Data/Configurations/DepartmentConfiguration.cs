using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "Department";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => e.DepartmentId);

            // Задается автогенерация для PK
            builder.Property(e => e.DepartmentId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DepartmentId)
                .HasColumnName("department_id")
                .HasComment("Идентификатор кафедры");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired(false)
                .HasComment("Название кафедры");

            builder.Property(e => e.HeadId)
                .HasColumnName("head_id")
                .IsRequired(false)
                .HasComment("Идентификатор главы кафедры");

            //Указание связей
            //builder.ToTable(TableName)
            //    .HasMany(e => e.Teachers)
            //    .WithOne(e => e.Department)
            //    //.HasForeignKey(e => e.DepartmentId)
            //    .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasOne(e => e.Head)
                .WithOne()
                .HasForeignKey<Department>(e => e.HeadId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasIndex(e => e.HeadId, "index_head_id");

        }
    }
}
