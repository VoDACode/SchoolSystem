using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class RmUserForeignKeyFromAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserForeignKey",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserForeignKey",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "UserForeignKey",
                table: "Admins");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Admins",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_Id",
                table: "Admins",
                column: "Id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_Id",
                table: "Admins");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Admins",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserForeignKey",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserForeignKey",
                table: "Admins",
                column: "UserForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserForeignKey",
                table: "Admins",
                column: "UserForeignKey",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
