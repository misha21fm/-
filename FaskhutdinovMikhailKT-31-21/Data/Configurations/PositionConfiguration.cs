using FaskhutdinovMikhailKT_31_21.Helpers;
using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "cs_position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => e.PositionId)
                .HasName($"pk_{TableName}_position_id");

            // Задается автогенерация для PK
            builder.Property(e => e.PositionId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PositionId)
                .HasColumnName("position_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор должности");

            builder.Property(e => e.Title)
                .HasColumnName("c_title")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .HasComment("Название должности");

            builder.ToTable(TableName);

        }
    }
}
