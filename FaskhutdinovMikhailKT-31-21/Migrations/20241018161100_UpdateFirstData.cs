using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FaskhutdinovMikhailKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 1,
                column: "f_department_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 2,
                column: "f_department_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 3,
                column: "f_department_id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 4,
                column: "f_department_id",
                value: 4);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 5,
                column: "f_department_id",
                value: 4);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 6,
                column: "f_department_id",
                value: 5);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 7,
                column: "f_department_id",
                value: 4);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 8,
                column: "f_department_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 9,
                column: "f_department_id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 10,
                column: "f_department_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 1,
                columns: new[] { "d_create", "f_head_id" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 11, 0, 565, DateTimeKind.Local).AddTicks(9043), 1 });

            migrationBuilder.UpdateData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 2,
                columns: new[] { "d_create", "f_head_id" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 11, 0, 565, DateTimeKind.Local).AddTicks(9056), 2 });

            migrationBuilder.UpdateData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 3,
                columns: new[] { "d_create", "f_head_id" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 11, 0, 565, DateTimeKind.Local).AddTicks(9059), 3 });

            migrationBuilder.UpdateData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 4,
                columns: new[] { "d_create", "f_head_id" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 11, 0, 565, DateTimeKind.Local).AddTicks(9061), 4 });

            migrationBuilder.UpdateData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 5,
                columns: new[] { "d_create", "f_head_id" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 11, 0, 565, DateTimeKind.Local).AddTicks(9063), 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 1,
                column: "f_department_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 2,
                column: "f_department_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 3,
                column: "f_department_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 4,
                column: "f_department_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 5,
                column: "f_department_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 6,
                column: "f_department_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 7,
                column: "f_department_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 8,
                column: "f_department_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 9,
                column: "f_department_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "cd_teacher",
                keyColumn: "teacher_id",
                keyValue: 10,
                column: "f_department_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 1,
                columns: new[] { "d_create", "f_head_id" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7147), null });

            migrationBuilder.UpdateData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 2,
                columns: new[] { "d_create", "f_head_id" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7160), null });

            migrationBuilder.UpdateData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 3,
                columns: new[] { "d_create", "f_head_id" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7162), null });

            migrationBuilder.UpdateData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 4,
                columns: new[] { "d_create", "f_head_id" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7163), null });

            migrationBuilder.UpdateData(
                table: "cs_department",
                keyColumn: "department_id",
                keyValue: 5,
                columns: new[] { "d_create", "f_head_id" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7165), null });

            migrationBuilder.InsertData(
                table: "cs_department",
                columns: new[] { "department_id", "d_create", "f_head_id", "c_name" },
                values: new object[,]
                {
                    { 6, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7166), null, "Electrical Engineering" },
                    { 7, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7167), null, "Mechanical Engineering" },
                    { 8, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7168), null, "Civil Engineering" },
                    { 9, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7170), null, "Economics" },
                    { 10, new DateTime(2024, 10, 18, 19, 4, 38, 7, DateTimeKind.Local).AddTicks(7171), null, "Psychology" }
                });
        }
    }
}
