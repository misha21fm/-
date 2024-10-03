using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "Discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => e.DisciplineId);

            // Задается автогенерация для PK
            builder.Property(e => e.DisciplineId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DisciplineId)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор дисциплины");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .HasComment("Название дисциплины");

            // Указание связей
            //builder.ToTable(TableName)
            //    .HasMany(e => e.TeacherDisciplines)
            //    .WithOne(e => e.Discipline)
            //    .HasForeignKey(e => e.DisciplineId)
            //    .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
