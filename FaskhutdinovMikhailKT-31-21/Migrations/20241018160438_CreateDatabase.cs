using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FaskhutdinovMikhailKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cs_academic_degree",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор ученой степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_academic_degree_academic_degree_id", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cs_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cs_position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_patronymic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    f_department_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор кафедры"),
                    f_academic_degree_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор ученой степени"),
                    f_position_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_f_academic_degree_id",
                        column: x => x.f_academic_degree_id,
                        principalTable: "cs_academic_degree",
                        principalColumn: "academic_degree_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_f_position_id",
                        column: x => x.f_position_id,
                        principalTable: "cs_position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher_discipline",
                columns: table => new
                {
                    f_teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя"),
                    f_discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины"),
                    n_workload_hours = table.Column<int>(type: "int", nullable: false, comment: "Рабочие часы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_discipline_teacher_discipline_id", x => new { x.f_discipline_id, x.f_teacher_id });
                    table.ForeignKey(
                        name: "fk_f_discipline_id",
                        column: x => x.f_discipline_id,
                        principalTable: "cs_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_teacher_id",
                        column: x => x.f_teacher_id,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cs_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Название кафедры"),
                    d_create = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Дата основания кафедры"),
                    f_head_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор главы кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_department_department_id", x => x.department_id);
                    table.ForeignKey(
                        name: "fk_f_head_id",
                        column: x => x.f_head_id,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "cs_academic_degree",
                columns: new[] { "academic_degree_id", "c_title" },
                values: new object[,]
                {
                    { 1, "PhD in Computer Science" },
                    { 2, "PhD in Mathematics" },
                    { 3, "PhD in Physics" },
                    { 4, "Master of Science" },
                    { 5, "Master of Arts" },
                    { 6, "Bachelor of Science" },
                    { 7, "Bachelor of Arts" },
                    { 8, "Doctor of Engineering" },
                    { 9, "Doctor of Philosophy" },
                    { 10, "Doctor of Education" }
                });

            migrationBuilder.InsertData(
                table: "cs_department",
                columns: new[] { "department_id", "d_create", "f_head_id", "c_name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7147), null, "Computer Science" },
                    { 2, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7160), null, "Mathematics" },
                    { 3, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7162), null, "Physics" },
                    { 4, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7163), null, "Chemistry" },
                    { 5, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7165), null, "Biology" },
                    { 6, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7166), null, "Electrical Engineering" },
                    { 7, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7167), null, "Mechanical Engineering" },
                    { 8, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7168), null, "Civil Engineering" },
                    { 9, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7170), null, "Economics" },
                    { 10, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7171), null, "Psychology" }
                });

            migrationBuilder.InsertData(
                table: "cs_discipline",
                columns: new[] { "discipline_id", "c_name" },
                values: new object[,]
                {
                    { 1, "Algorithms and Data Structures" },
                    { 2, "Linear Algebra" },
                    { 3, "Quantum Mechanics" },
                    { 4, "Organic Chemistry" },
                    { 5, "Genetics" },
                    { 6, "Circuit Design" },
                    { 7, "Thermodynamics" },
                    { 8, "Structural Analysis" },
                    { 9, "Microeconomics" },
                    { 10, "Cognitive Psychology" }
                });

            migrationBuilder.InsertData(
                table: "cs_position",
                columns: new[] { "position_id", "c_title" },
                values: new object[,]
                {
                    { 1, "Professor" },
                    { 2, "Associate Professor" },
                    { 3, "Assistant Professor" },
                    { 4, "Lecturer" },
                    { 5, "Research Fellow" },
                    { 6, "Teaching Assistant" },
                    { 7, "Lab Instructor" },
                    { 8, "Department Chair" },
                    { 9, "Dean" },
                    { 10, "Academic Advisor" }
                });

            migrationBuilder.InsertData(
                table: "cd_teacher",
                columns: new[] { "teacher_id", "f_academic_degree_id", "f_department_id", "c_firstname", "c_lastname", "c_patronymic", "f_position_id" },
                values: new object[,]
                {
                    { 1, 1, null, "John", "Smith", "A.", 1 },
                    { 2, 2, null, "Alice", "Johnson", "B.", 2 },
                    { 3, 3, null, "Robert", "Brown", "C.", 3 },
                    { 4, 4, null, "Mary", "Jones", "D.", 4 },
                    { 5, 5, null, "Michael", "Williams", "E.", 5 },
                    { 6, 6, null, "Patricia", "Garcia", "F.", 6 },
                    { 7, 7, null, "Linda", "Miller", "G.", 7 },
                    { 8, 8, null, "James", "Martinez", "H.", 8 },
                    { 9, 9, null, "Barbara", "Lopez", "I.", 9 },
                    { 10, 10, null, "David", "Wilson", "J.", 10 }
                });

            migrationBuilder.InsertData(
                table: "cd_teacher_discipline",
                columns: new[] { "f_discipline_id", "f_teacher_id", "n_workload_hours" },
                values: new object[,]
                {
                    { 1, 1, 100 },
                    { 2, 2, 80 },
                    { 3, 3, 90 },
                    { 4, 4, 110 },
                    { 5, 5, 95 },
                    { 6, 6, 70 },
                    { 7, 7, 85 },
                    { 8, 8, 120 },
                    { 9, 9, 75 },
                    { 10, 10, 65 }
                });

            migrationBuilder.CreateIndex(
                name: "idx_academic_degree_id",
                table: "cd_teacher",
                column: "f_academic_degree_id");

            migrationBuilder.CreateIndex(
                name: "idx_department_id",
                table: "cd_teacher",
                column: "f_department_id");

            migrationBuilder.CreateIndex(
                name: "idx_position_id",
                table: "cd_teacher",
                column: "f_position_id");

            migrationBuilder.CreateIndex(
                name: "idx_discipline_id",
                table: "cd_teacher_discipline",
                column: "f_discipline_id");

            migrationBuilder.CreateIndex(
                name: "idx_teacher_id",
                table: "cd_teacher_discipline",
                column: "f_teacher_id");

            migrationBuilder.CreateIndex(
                name: "idx_head_id",
                table: "cs_department",
                column: "f_head_id");

            migrationBuilder.CreateIndex(
                name: "IX_cs_department_f_head_id",
                table: "cs_department",
                column: "f_head_id",
                unique: true,
                filter: "[f_head_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "fk_f_department_id",
                table: "cd_teacher",
                column: "f_department_id",
                principalTable: "cs_department",
                principalColumn: "department_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_academic_degree_id",
                table: "cd_teacher");

            migrationBuilder.DropForeignKey(
                name: "fk_f_department_id",
                table: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_teacher_discipline");

            migrationBuilder.DropTable(
                name: "cs_discipline");

            migrationBuilder.DropTable(
                name: "cs_academic_degree");

            migrationBuilder.DropTable(
                name: "cs_department");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cs_position");
        }
    }
}
