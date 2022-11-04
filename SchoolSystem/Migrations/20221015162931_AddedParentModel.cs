using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedParentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    parent_email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    parent_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.parent_id);
                    table.ForeignKey(
                        name: "FK_Parents_Users_parent_id",
                        column: x => x.parent_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parents_parent_email",
                table: "Parents",
                column: "parent_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_parent_id",
                table: "Parents",
                column: "parent_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
