using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedControlMark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlMarks",
                columns: table => new
                {
                    DisciplineCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    MarkType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    create_date_mark = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlMarks", x => new { x.StudentId, x.TeacherId, x.DisciplineCode, x.MarkType });
                    table.ForeignKey(
                        name: "FK_ControlMarks_Disciplines_DisciplineCode",
                        column: x => x.DisciplineCode,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_code",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ControlMarks_MarkTypes_MarkType",
                        column: x => x.MarkType,
                        principalTable: "MarkTypes",
                        principalColumn: "mark_type",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ControlMarks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ControlMarks_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlMarks_DisciplineCode1",
                table: "ControlMarks",
                column: "DisciplineCode");

            migrationBuilder.CreateIndex(
                name: "IX_ControlMarks_MarkType",
                table: "ControlMarks",
                column: "MarkType");

            migrationBuilder.CreateIndex(
                name: "IX_ControlMarks_TeacherId",
                table: "ControlMarks",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlMarks_StudentId",
                table: "ControlMarks",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlMarks");
        }
    }
}
