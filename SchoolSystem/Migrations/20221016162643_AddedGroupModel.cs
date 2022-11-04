using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedGroupModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    group_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date_of_creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    group_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.group_code);
                    table.ForeignKey(
                        name: "FK_Groups_Teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_teacher_id",
                table: "Groups",
                column: "teacher_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
