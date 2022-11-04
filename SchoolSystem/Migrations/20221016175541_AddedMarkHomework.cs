using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedMarkHomework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarkHomeworks",
                columns: table => new
                {
                    homework_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    answer_file_id = table.Column<int>(type: "int", nullable: true, defaultValue: null),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    check_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mark = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkHomeworks", x => new { x.student_id, x.homework_id });
                    table.ForeignKey(
                        name: "FK_MarkHomeworks_Files_AnswerFileId",
                        column: x => x.answer_file_id,
                        principalTable: "Files",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MarkHomeworks_Homeworks_HomeworkId",
                        column: x => x.homework_id,
                        principalTable: "Homeworks",
                        principalColumn: "homework_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MarkHomeworks_Students_StudentId",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarkHomeworks_StudentId",
                table: "MarkHomeworks",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_MarkHomeworks_HomeworkId",
                table: "MarkHomeworks",
                column: "homework_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarkHomeworks");
        }
    }
}
