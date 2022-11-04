using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedHomeworkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    homework_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discipline_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    group_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    publication_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    closing_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    homework_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    homework_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.homework_id);
                    table.ForeignKey(
                        name: "FK_Homeworks_Disciplines_DisciplineCode",
                        column: x => x.discipline_code,
                        principalTable: "Disciplines",
                        principalColumn: "discipline_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Homeworks_Files_FileId",
                        column: x => x.file_id,
                        principalTable: "Files",
                        principalColumn: "file_id");
                    table.ForeignKey(
                        name: "FK_Homeworks_Groups_GroupCode",
                        column: x => x.group_code,
                        principalTable: "Groups",
                        principalColumn: "group_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_DisciplineCode",
                table: "Homeworks",
                column: "discipline_code");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_FileId",
                table: "Homeworks",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_GroupCode",
                table: "Homeworks",
                column: "group_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homeworks");
        }
    }
}
