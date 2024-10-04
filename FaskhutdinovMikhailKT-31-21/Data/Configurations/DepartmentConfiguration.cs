using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FaskhutdinovMikhailKT_31_21.Helpers;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cs_department";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => e.DepartmentId)
                .HasName($"pk_{TableName}_department_id");

            // Задается автогенерация для PK
            builder.Property(e => e.DepartmentId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DepartmentId)
                .HasColumnName("department_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор кафедры");//Тип колонки укажи. Везде.

            builder.Property(e => e.Name)
                .HasColumnName("c_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .IsRequired(false)
                .HasComment("Название кафедры");

            builder.Property(e => e.HeadId)
                .HasColumnName("f_head_id")
                .HasColumnType(ColumnType.Int)
                .IsRequired(false)
                .HasComment("Идентификатор главы кафедры");

            // Указание связей
            builder.ToTable(TableName)
                .HasOne(e => e.Head)
                .WithOne()
                .HasForeignKey<Department>(e => e.HeadId)
//                .IsRequired(false)
                .HasConstraintName("fk_f_head_id")
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasIndex(e => e.HeadId, "idx_head_id");

        }
    }
}
