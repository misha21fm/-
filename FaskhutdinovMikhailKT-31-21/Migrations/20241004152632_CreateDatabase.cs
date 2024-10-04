using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaskhutdinovMikhailKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор ученой степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegrees", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Название кафедры"),
                    head_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор главы кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    patronymic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    department_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор кафедры"),
                    academic_degree_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор ученой степени"),
                    position_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.teacher_id);
                    table.ForeignKey(
                        name: "FK_Teacher_AcademicDegrees_academic_degree_id",
                        column: x => x.academic_degree_id,
                        principalTable: "AcademicDegrees",
                        principalColumn: "academic_degree_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Teacher_Department_department_id",
                        column: x => x.department_id,
                        principalTable: "Department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Teacher_Positions_position_id",
                        column: x => x.position_id,
                        principalTable: "Positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDiscipline",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя"),
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины"),
                    workload_hours = table.Column<int>(type: "int", nullable: false, comment: "Рабочие часы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teacher_discipline", x => new { x.discipline_id, x.teacher_id });
                    table.ForeignKey(
                        name: "FK_TeacherDiscipline_Disciplines_discipline_id",
                        column: x => x.discipline_id,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherDiscipline_Teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "Teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "index_head_id",
                table: "Department",
                column: "head_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_head_id",
                table: "Department",
                column: "head_id",
                unique: true,
                filter: "[head_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "index_academic_degree_id",
                table: "Teacher",
                column: "academic_degree_id");

            migrationBuilder.CreateIndex(
                name: "index_department_id",
                table: "Teacher",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "index_position_id",
                table: "Teacher",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDiscipline_teacher_id",
                table: "TeacherDiscipline",
                column: "teacher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Teacher_head_id",
                table: "Department",
                column: "head_id",
                principalTable: "Teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Teacher_head_id",
                table: "Department");

            migrationBuilder.DropTable(
                name: "TeacherDiscipline");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "AcademicDegrees");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
