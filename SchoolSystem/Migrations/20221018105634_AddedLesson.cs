using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    lesson_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupCode1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    discipline_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisciplineCode1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    start_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_of_classes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lesson_topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonTypeTypeName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.lesson_id);
                    table.ForeignKey(
                        name: "FK_Lessons_Disciplines_DisciplineCode1",
                        column: x => x.DisciplineCode1,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Groups_GroupCode1",
                        column: x => x.GroupCode1,
                        principalTable: "Groups",
                        principalColumn: "group_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_LessonTypes_LessonTypeTypeName",
                        column: x => x.LessonTypeTypeName,
                        principalTable: "LessonTypes",
                        principalColumn: "lesson_type_name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DisciplineCode1",
                table: "Lessons",
                column: "DisciplineCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupCode1",
                table: "Lessons",
                column: "GroupCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonTypeTypeName",
                table: "Lessons",
                column: "LessonTypeTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
