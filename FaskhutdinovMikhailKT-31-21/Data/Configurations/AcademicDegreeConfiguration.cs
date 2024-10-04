using FaskhutdinovMikhailKT_31_21.Helpers;
using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {

        private const string TableName = "cs_academic_degree";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => e.AcademicDegreeId)
                .HasName($"pk_{TableName}_academic_degree_id");

            // Задается автогенерация для PK
            builder.Property(e => e.AcademicDegreeId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.AcademicDegreeId)
                .HasColumnName("academic_degree_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор ученой степени");

            builder.Property(e => e.Title)
                .HasColumnName("c_title")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .HasComment("Название ученой степени");

            builder.ToTable(TableName);

        }

    }
}
