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
