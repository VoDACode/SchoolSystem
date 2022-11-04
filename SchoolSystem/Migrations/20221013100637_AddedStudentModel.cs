using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedStudentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    date_of_entry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_of_end = table.Column<DateTime>(type: "datetime2", nullable: true),
                    student_type = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    country = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    region_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    area_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    settlement_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    street_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    house_numder = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    flat_numder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.student_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "student_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
