using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class AddedRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTeacherRatings");

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_RatingId",
                table: "Groups",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Ratings_RatingId",
                table: "Groups",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Ratings_RatingId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_RatingId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "GroupTeacherRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTeacherRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupTeacherRatings_Groups_GroupCode",
                        column: x => x.GroupCode,
                        principalTable: "Groups",
                        principalColumn: "group_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTeacherRatings_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupTeacherRatings_GroupCode",
                table: "GroupTeacherRatings",
                column: "GroupCode");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTeacherRatings_RatingId",
                table: "GroupTeacherRatings",
                column: "RatingId");
        }
    }
}
