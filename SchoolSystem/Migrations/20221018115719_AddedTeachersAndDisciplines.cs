using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedTeachersAndDisciplines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisciplineTeacher",
                columns: table => new
                {
                    DisciplinesDisciplineCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeachersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineTeacher", x => new { x.DisciplinesDisciplineCode, x.TeachersUserId });
                    table.ForeignKey(
                        name: "FK_DisciplineTeacher_Disciplines_DisciplinesDisciplineCode",
                        column: x => x.DisciplinesDisciplineCode,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineTeacher_Teachers_TeachersUserId",
                        column: x => x.TeachersUserId,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineTeacher_TeachersUserId",
                table: "DisciplineTeacher",
                column: "TeachersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplineTeacher");
        }
    }
}
