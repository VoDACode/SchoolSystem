using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserID",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Students_student_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Teachers_teacher_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlMarks_Students_StudentId",
                table: "ControlMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlMarks_Teachers_TeacherId",
                table: "ControlMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineTeacher_Teachers_TeachersUserID",
                table: "DisciplineTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_teacher_id",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_Students_StudentsUserID",
                table: "GroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_MarkHomeworks_Students_StudentId",
                table: "MarkHomeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_MarkLessons_Students_StudentId",
                table: "MarkLessons");

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

            migrationBuilder.DropForeignKey(
                name: "FK_Visitations_Students_StudentId",
                table: "Visitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Teachers",
                newName: "UserForeignKey");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Students",
                newName: "UserId");

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
                newName: "UserForeignKey");

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
                newName: "UserForeignKey");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserForeignKey",
                table: "Teachers",
                column: "UserForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_UserForeignKey",
                table: "Parents",
                column: "UserForeignKey",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Students_student_id",
                table: "Comments",
                column: "student_id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Teachers_teacher_id",
                table: "Comments",
                column: "teacher_id",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlMarks_Students_StudentId",
                table: "ControlMarks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlMarks_Teachers_TeacherId",
                table: "ControlMarks",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineTeacher_Teachers_TeachersId",
                table: "DisciplineTeacher",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_teacher_id",
                table: "Groups",
                column: "teacher_id",
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
                name: "FK_MarkHomeworks_Students_StudentId",
                table: "MarkHomeworks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarkLessons_Students_StudentId",
                table: "MarkLessons",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Users_UserForeignKey",
                table: "Parents",
                column: "UserForeignKey",
                principalTable: "Users",
                principalColumn: "user_id",
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
                name: "FK_Students_Users_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users_UserForeignKey",
                table: "Teachers",
                column: "UserForeignKey",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitations_Students_StudentId",
                table: "Visitations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserForeignKey",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Students_student_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Teachers_teacher_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlMarks_Students_StudentId",
                table: "ControlMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlMarks_Teachers_TeacherId",
                table: "ControlMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineTeacher_Teachers_TeachersId",
                table: "DisciplineTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_teacher_id",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_Students_StudentsId",
                table: "GroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_MarkHomeworks_Students_StudentId",
                table: "MarkHomeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_MarkLessons_Students_StudentId",
                table: "MarkLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Users_UserForeignKey",
                table: "Parents");

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
                name: "FK_Students_Users_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users_UserForeignKey",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitations_Students_StudentId",
                table: "Visitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserForeignKey",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_UserForeignKey",
                table: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserForeignKey",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "UserForeignKey",
                table: "Teachers",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
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
                name: "UserForeignKey",
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
                name: "UserForeignKey",
                table: "Admins",
                newName: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserID",
                table: "Admins",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Students_student_id",
                table: "Comments",
                column: "student_id",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Teachers_teacher_id",
                table: "Comments",
                column: "teacher_id",
                principalTable: "Teachers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlMarks_Students_StudentId",
                table: "ControlMarks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlMarks_Teachers_TeacherId",
                table: "ControlMarks",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineTeacher_Teachers_TeachersUserID",
                table: "DisciplineTeacher",
                column: "TeachersUserID",
                principalTable: "Teachers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_teacher_id",
                table: "Groups",
                column: "teacher_id",
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
                name: "FK_MarkHomeworks_Students_StudentId",
                table: "MarkHomeworks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarkLessons_Students_StudentId",
                table: "MarkLessons",
                column: "StudentId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Visitations_Students_StudentId",
                table: "Visitations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
