﻿using FaskhutdinovMikhailKT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaskhutdinovMikhailKT_31_21.Data.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {

        private const string TableName = "AcademicDegree";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            // Задается ключ
            builder
                .HasKey(e => e.AcademicDegreeId);

            // Задается автогенерация для PK
            builder.Property(e => e.AcademicDegreeId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.AcademicDegreeId)
                .HasColumnName("academic_degree_id")
                .HasComment("Идентификатор ученой степени");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(100)
                .HasComment("Название ученой степени");

            // Указание связей
            //builder.ToTable(TableName)
            //    .HasMany(e => e.Teachers)
            //    .WithOne(e => e.AcademicDegree)
            //    .HasForeignKey(e => e.AcademicDegreeId)
            //    .OnDelete(DeleteBehavior.SetNull);


        }

    }
}
