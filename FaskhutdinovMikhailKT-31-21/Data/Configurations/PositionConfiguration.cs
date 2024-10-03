using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "Position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => e.PositionId);

            // Задается автогенерация для PK
            builder.Property(e => e.PositionId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PositionId)
                .HasColumnName("position_id")
                .HasComment("Идентификатор должности");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(100)
                .HasComment("Название должности");

            // Указание связей
            //builder.ToTable(TableName)
            //    .HasMany(e => e.Teachers)
            //    .WithOne(e => e.Position)
            //    .HasForeignKey(e => e.PositionId)
            //    .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
