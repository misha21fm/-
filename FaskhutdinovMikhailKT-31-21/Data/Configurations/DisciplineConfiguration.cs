using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FaskhutdinovMikhailKT_31_21.Helpers;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cs_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => e.DisciplineId)
                .HasName($"pk_{TableName}_discipline_id");

            // Задается автогенерация для PK
            builder.Property(e => e.DisciplineId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DisciplineId)
                .HasColumnName("discipline_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор дисциплины");

            builder.Property(e => e.Name)
                .HasColumnName("c_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .HasComment("Название дисциплины");

            builder.ToTable(TableName);

        }
    }
}
