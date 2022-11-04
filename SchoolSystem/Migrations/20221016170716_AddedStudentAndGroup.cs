using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedStudentAndGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupStudent",
                columns: table => new
                {
                    GroupsGroupCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentsUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudent", x => new { x.GroupsGroupCode, x.StudentsUserId });
                    table.ForeignKey(
                        name: "FK_GroupStudent_Groups_GroupsGroupCode",
                        column: x => x.GroupsGroupCode,
                        principalTable: "Groups",
                        principalColumn: "group_code",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GroupStudent_Students_StudentsUserId",
                        column: x => x.StudentsUserId,
                        principalTable: "Students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudent_StudentsUserId",
                table: "GroupStudent",
                column: "StudentsUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupStudent");
        }
    }
}
