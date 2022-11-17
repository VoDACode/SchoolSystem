using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedRefUserRoleToUserFixIdError2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineTeacher_Teachers_TeachersId",
                table: "DisciplineTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_Students_StudentsId",
                table: "GroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudent_Parents_ParentsId",
                table: "ParentStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudent_Students_StudentsId",
                table: "ParentStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Teachers_TeacherId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingVoices_Students_StudentId",
                table: "RatingVoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Admins_user_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Parents_user_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_user_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teachers_user_id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "RatingVoices",
                newName: "StudentUserID");

            migrationBuilder.RenameIndex(
                name: "IX_RatingVoices_StudentId",
                table: "RatingVoices",
                newName: "IX_RatingVoices_StudentUserID");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Ratings",
                newName: "TeacherUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_TeacherId",
                table: "Ratings",
                newName: "IX_Ratings_TeacherUserID");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "ParentStudent",
                newName: "StudentsUserID");

            migrationBuilder.RenameColumn(
                name: "ParentsId",
                table: "ParentStudent",
                newName: "ParentsUserID");

            migrationBuilder.RenameIndex(
                name: "IX_ParentStudent_StudentsId",
                table: "ParentStudent",
                newName: "IX_ParentStudent_StudentsUserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Parents",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "GroupStudent",
                newName: "StudentsUserID");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudent_StudentsId",
                table: "GroupStudent",
                newName: "IX_GroupStudent_StudentsUserID");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "DisciplineTeacher",
                newName: "TeachersUserID");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplineTeacher_TeachersId",
                table: "DisciplineTeacher",
                newName: "IX_DisciplineTeacher_TeachersUserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admins",
                newName: "UserID");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Parents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Admins",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserID",
                table: "Admins",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineTeacher_Teachers_TeachersUserID",
                table: "DisciplineTeacher",
                column: "TeachersUserID",
                principalTable: "Teachers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudent_Students_StudentsUserID",
                table: "GroupStudent",
                column: "StudentsUserID",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Users_UserID",
                table: "Parents",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudent_Parents_ParentsUserID",
                table: "ParentStudent",
                column: "ParentsUserID",
                principalTable: "Parents",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudent_Students_StudentsUserID",
                table: "ParentStudent",
                column: "StudentsUserID",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Teachers_TeacherUserID",
                table: "Ratings",
                column: "TeacherUserID",
                principalTable: "Teachers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RatingVoices_Students_StudentUserID",
                table: "RatingVoices",
                column: "StudentUserID",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserID",
                table: "Students",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users_UserID",
                table: "Teachers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserID",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineTeacher_Teachers_TeachersUserID",
                table: "DisciplineTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_Students_StudentsUserID",
                table: "GroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Users_UserID",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudent_Parents_ParentsUserID",
                table: "ParentStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudent_Students_StudentsUserID",
                table: "ParentStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Teachers_TeacherUserID",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingVoices_Students_StudentUserID",
                table: "RatingVoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users_UserID",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentUserID",
                table: "RatingVoices",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_RatingVoices_StudentUserID",
                table: "RatingVoices",
                newName: "IX_RatingVoices_StudentId");

            migrationBuilder.RenameColumn(
                name: "TeacherUserID",
                table: "Ratings",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_TeacherUserID",
                table: "Ratings",
                newName: "IX_Ratings_TeacherId");

            migrationBuilder.RenameColumn(
                name: "StudentsUserID",
                table: "ParentStudent",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "ParentsUserID",
                table: "ParentStudent",
                newName: "ParentsId");

            migrationBuilder.RenameIndex(
                name: "IX_ParentStudent_StudentsUserID",
                table: "ParentStudent",
                newName: "IX_ParentStudent_StudentsId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Parents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentsUserID",
                table: "GroupStudent",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudent_StudentsUserID",
                table: "GroupStudent",
                newName: "IX_GroupStudent_StudentsId");

            migrationBuilder.RenameColumn(
                name: "TeachersUserID",
                table: "DisciplineTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplineTeacher_TeachersUserID",
                table: "DisciplineTeacher",
                newName: "IX_DisciplineTeacher_TeachersId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Admins",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Parents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Admins",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineTeacher_Teachers_TeachersId",
                table: "DisciplineTeacher",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudent_Students_StudentsId",
                table: "GroupStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudent_Parents_ParentsId",
                table: "ParentStudent",
                column: "ParentsId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudent_Students_StudentsId",
                table: "ParentStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Teachers_TeacherId",
                table: "Ratings",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RatingVoices_Students_StudentId",
                table: "RatingVoices",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Admins_user_id",
                table: "Users",
                column: "user_id",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Parents_user_id",
                table: "Users",
                column: "user_id",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_user_id",
                table: "Users",
                column: "user_id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teachers_user_id",
                table: "Users",
                column: "user_id",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
