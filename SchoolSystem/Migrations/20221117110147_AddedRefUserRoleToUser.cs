using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedRefUserRoleToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineTeacher_Teachers_TeachersUser_Id",
                table: "DisciplineTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_Students_StudentsUser_Id",
                table: "GroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Users_UserId",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudent_Parents_ParentsUser_Id",
                table: "ParentStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudent_Students_StudentsUser_Id",
                table: "ParentStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Teachers_TeacherUser_Id",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingVoices_Students_StudentUser_Id",
                table: "RatingVoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users_UserId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_UserId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "teacher_id",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentUser_Id",
                table: "RatingVoices",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_RatingVoices_StudentUser_Id",
                table: "RatingVoices",
                newName: "IX_RatingVoices_StudentId");

            migrationBuilder.RenameColumn(
                name: "TeacherUser_Id",
                table: "Ratings",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_TeacherUser_Id",
                table: "Ratings",
                newName: "IX_Ratings_TeacherId");

            migrationBuilder.RenameColumn(
                name: "StudentsUser_Id",
                table: "ParentStudent",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "ParentsUser_Id",
                table: "ParentStudent",
                newName: "ParentsId");

            migrationBuilder.RenameIndex(
                name: "IX_ParentStudent_StudentsUser_Id",
                table: "ParentStudent",
                newName: "IX_ParentStudent_StudentsId");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "Parents",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "StudentsUser_Id",
                table: "GroupStudent",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudent_StudentsUser_Id",
                table: "GroupStudent",
                newName: "IX_GroupStudent_StudentsId");

            migrationBuilder.RenameColumn(
                name: "TeachersUser_Id",
                table: "DisciplineTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplineTeacher_TeachersUser_Id",
                table: "DisciplineTeacher",
                newName: "IX_DisciplineTeacher_TeachersId");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "User_Id",
                table: "Parents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Parents");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "teacher_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "student_id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "RatingVoices",
                newName: "StudentUser_Id");

            migrationBuilder.RenameIndex(
                name: "IX_RatingVoices_StudentId",
                table: "RatingVoices",
                newName: "IX_RatingVoices_StudentUser_Id");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Ratings",
                newName: "TeacherUser_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_TeacherId",
                table: "Ratings",
                newName: "IX_Ratings_TeacherUser_Id");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "ParentStudent",
                newName: "StudentsUser_Id");

            migrationBuilder.RenameColumn(
                name: "ParentsId",
                table: "ParentStudent",
                newName: "ParentsUser_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ParentStudent_StudentsId",
                table: "ParentStudent",
                newName: "IX_ParentStudent_StudentsUser_Id");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Parents",
                newName: "parent_id");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "GroupStudent",
                newName: "StudentsUser_Id");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudent_StudentsId",
                table: "GroupStudent",
                newName: "IX_GroupStudent_StudentsUser_Id");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "DisciplineTeacher",
                newName: "TeachersUser_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplineTeacher_TeachersId",
                table: "DisciplineTeacher",
                newName: "IX_DisciplineTeacher_TeachersUser_Id");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "parent_id",
                table: "Parents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Parents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_UserId",
                table: "Parents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineTeacher_Teachers_TeachersUser_Id",
                table: "DisciplineTeacher",
                column: "TeachersUser_Id",
                principalTable: "Teachers",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudent_Students_StudentsUser_Id",
                table: "GroupStudent",
                column: "StudentsUser_Id",
                principalTable: "Students",
                principalColumn: "student_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Users_UserId",
                table: "Parents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudent_Parents_ParentsUser_Id",
                table: "ParentStudent",
                column: "ParentsUser_Id",
                principalTable: "Parents",
                principalColumn: "parent_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudent_Students_StudentsUser_Id",
                table: "ParentStudent",
                column: "StudentsUser_Id",
                principalTable: "Students",
                principalColumn: "student_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Teachers_TeacherUser_Id",
                table: "Ratings",
                column: "TeacherUser_Id",
                principalTable: "Teachers",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RatingVoices_Students_StudentUser_Id",
                table: "RatingVoices",
                column: "StudentUser_Id",
                principalTable: "Students",
                principalColumn: "student_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users_UserId",
                table: "Teachers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "user_id");
        }
    }
}
