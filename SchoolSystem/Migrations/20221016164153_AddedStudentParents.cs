using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedStudentParents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParentStudent",
                columns: table => new
                {
                    ParentsUserId = table.Column<int>(type: "int", nullable: false),
                    StudentsUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentStudent", x => new { x.ParentsUserId, x.StudentsUserId });
                    table.ForeignKey(
                        name: "FK_ParentStudent_Parents_ParentsUserId",
                        column: x => x.ParentsUserId,
                        principalTable: "Parents",
                        principalColumn: "parent_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ParentStudent_Students_StudentsUserId",
                        column: x => x.StudentsUserId,
                        principalTable: "Students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParentStudent_StudentsUserId",
                table: "ParentStudent",
                column: "StudentsUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParentStudent");
        }
    }
}
