using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class UpdateLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Disciplines_DisciplineCode1",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Groups_GroupCode1",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_DisciplineCode1",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_GroupCode1",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DisciplineCode1",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "GroupCode1",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "group_code",
                table: "Lessons",
                newName: "GroupCode");

            migrationBuilder.RenameColumn(
                name: "discipline_code",
                table: "Lessons",
                newName: "DisciplineCode");

            migrationBuilder.AlterColumn<string>(
                name: "GroupCode",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DisciplineCode",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DisciplineCode",
                table: "Lessons",
                column: "DisciplineCode");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupCode",
                table: "Lessons",
                column: "GroupCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Disciplines_DisciplineCode",
                table: "Lessons",
                column: "DisciplineCode",
                principalTable: "Disciplines",
                principalColumn: "discipline_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Groups_GroupCode",
                table: "Lessons",
                column: "GroupCode",
                principalTable: "Groups",
                principalColumn: "group_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Disciplines_DisciplineCode",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Groups_GroupCode",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_DisciplineCode",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_GroupCode",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "GroupCode",
                table: "Lessons",
                newName: "group_code");

            migrationBuilder.RenameColumn(
                name: "DisciplineCode",
                table: "Lessons",
                newName: "discipline_code");

            migrationBuilder.AlterColumn<string>(
                name: "group_code",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "discipline_code",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "DisciplineCode1",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GroupCode1",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DisciplineCode1",
                table: "Lessons",
                column: "DisciplineCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupCode1",
                table: "Lessons",
                column: "GroupCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Disciplines_DisciplineCode1",
                table: "Lessons",
                column: "DisciplineCode1",
                principalTable: "Disciplines",
                principalColumn: "discipline_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Groups_GroupCode1",
                table: "Lessons",
                column: "GroupCode1",
                principalTable: "Groups",
                principalColumn: "group_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
