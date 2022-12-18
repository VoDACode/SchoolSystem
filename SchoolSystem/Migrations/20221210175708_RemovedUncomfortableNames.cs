using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUncomfortableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Students_student_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Teachers_teacher_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlMarks_Disciplines_Discipline_Code",
                table: "ControlMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineTeacher_Disciplines_DisciplinesDiscipline_Code",
                table: "DisciplineTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_teacher_id",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Disciplines_Discipline_Code",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Disciplines_Discipline_Code",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ControlMarks",
                table: "ControlMarks");

            migrationBuilder.DropIndex(
                name: "IX_ControlMarks_Discipline_Code",
                table: "ControlMarks");

            migrationBuilder.RenameColumn(
                name: "visitation_status",
                table: "Visitations",
                newName: "VisitationStatus");

            migrationBuilder.RenameColumn(
                name: "late_for",
                table: "Visitations",
                newName: "LataFor");

            migrationBuilder.RenameColumn(
                name: "date_of_marking",
                table: "Visitations",
                newName: "DateOfMarking");

            migrationBuilder.RenameColumn(
                name: "birthday",
                table: "Users",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "user_password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "user_login",
                table: "Users",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "middle_name",
                table: "Users",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "date_start_work",
                table: "Teachers",
                newName: "DateStartWork");

            migrationBuilder.RenameColumn(
                name: "date_end_work",
                table: "Teachers",
                newName: "DateEndWork");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Students",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "student_type",
                table: "Students",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "street_name",
                table: "Students",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "settlement_name",
                table: "Students",
                newName: "Settlement");

            migrationBuilder.RenameColumn(
                name: "region_name",
                table: "Students",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "house_numder",
                table: "Students",
                newName: "House");

            migrationBuilder.RenameColumn(
                name: "flat_numder",
                table: "Students",
                newName: "Flat");

            migrationBuilder.RenameColumn(
                name: "date_of_entry",
                table: "Students",
                newName: "DateOfEntry");

            migrationBuilder.RenameColumn(
                name: "date_of_end",
                table: "Students",
                newName: "DateOfEnd");

            migrationBuilder.RenameColumn(
                name: "area_name",
                table: "Students",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "mark_type",
                table: "MarkTypes",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "mark",
                table: "MarkLessons",
                newName: "Mark");

            migrationBuilder.RenameColumn(
                name: "distinction",
                table: "MarkLessons",
                newName: "Distinction");

            migrationBuilder.RenameColumn(
                name: "mark",
                table: "MarkHomeworks",
                newName: "Mark");

            migrationBuilder.RenameColumn(
                name: "release_date",
                table: "MarkHomeworks",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "check_date",
                table: "MarkHomeworks",
                newName: "CheckDate");

            migrationBuilder.RenameColumn(
                name: "lesson_type_name",
                table: "LessonTypes",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "start_time",
                table: "Lessons",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "lesson_topic",
                table: "Lessons",
                newName: "Topic");

            migrationBuilder.RenameColumn(
                name: "end_time",
                table: "Lessons",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "date_of_classes",
                table: "Lessons",
                newName: "DateOfClasses");

            migrationBuilder.RenameColumn(
                name: "lesson_id",
                table: "Lessons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Discipline_Code",
                table: "Lessons",
                newName: "DisciplineCode");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_Discipline_Code",
                table: "Lessons",
                newName: "IX_Lessons_DisciplineCode");

            migrationBuilder.RenameColumn(
                name: "publication_date",
                table: "Homeworks",
                newName: "PublicationDate");

            migrationBuilder.RenameColumn(
                name: "homework_title",
                table: "Homeworks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "homework_description",
                table: "Homeworks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "closing_date",
                table: "Homeworks",
                newName: "ClosingDate");

            migrationBuilder.RenameColumn(
                name: "homework_id",
                table: "Homeworks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Discipline_Code",
                table: "Homeworks",
                newName: "DisciplineCode");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_Discipline_Code",
                table: "Homeworks",
                newName: "IX_Homeworks_DisciplineCode");

            migrationBuilder.RenameColumn(
                name: "teacher_id",
                table: "Groups",
                newName: "ClassTeacherId");

            migrationBuilder.RenameColumn(
                name: "group_status",
                table: "Groups",
                newName: "GroupStatus");

            migrationBuilder.RenameColumn(
                name: "date_of_creation",
                table: "Groups",
                newName: "DateOfCreation");

            migrationBuilder.RenameColumn(
                name: "group_code",
                table: "Groups",
                newName: "GroupCode");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_teacher_id",
                table: "Groups",
                newName: "IX_Groups_ClassTeacherId");

            migrationBuilder.RenameColumn(
                name: "file_siez",
                table: "Files",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "Files",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "file_id",
                table: "Files",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DisciplinesDiscipline_Code",
                table: "DisciplineTeacher",
                newName: "DisciplinesDisciplineCode");

            migrationBuilder.RenameColumn(
                name: "discipline_full_name",
                table: "Disciplines",
                newName: "DisciplineFullName");

            migrationBuilder.RenameColumn(
                name: "discipline_code",
                table: "Disciplines",
                newName: "DisciplineCode");

            migrationBuilder.RenameColumn(
                name: "mark",
                table: "ControlMarks",
                newName: "Mark");

            migrationBuilder.RenameColumn(
                name: "create_date_mark",
                table: "ControlMarks",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Discipline_Code",
                table: "ControlMarks",
                newName: "DisciplineCodeCode");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Comments",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "teacher_id",
                table: "Comments",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "Comments",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "date_of_writing",
                table: "Comments",
                newName: "DateOfWriting");

            migrationBuilder.RenameColumn(
                name: "comment_id",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_teacher_id",
                table: "Comments",
                newName: "IX_Comments_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_student_id",
                table: "Comments",
                newName: "IX_Comments_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "HighLevel",
                table: "LessonTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InitialLevel",
                table: "LessonTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxLevel",
                table: "LessonTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinLevel",
                table: "LessonTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SufficientLevel",
                table: "LessonTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ControlMarks",
                table: "ControlMarks",
                columns: new[] { "StudentId", "TeacherId", "DisciplineCodeCode", "MarkType" });

            migrationBuilder.CreateIndex(
                name: "IX_ControlMarks_DisciplineCode",
                table: "ControlMarks",
                column: "DisciplineCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Students_StudentId",
                table: "Comments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Teachers_TeacherId",
                table: "Comments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlMarks_Disciplines_DisciplineCode",
                table: "ControlMarks",
                column: "DisciplineCode",
                principalTable: "Disciplines",
                principalColumn: "DisciplineCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineTeacher_Disciplines_DisciplinesDisciplineCode",
                table: "DisciplineTeacher",
                column: "DisciplinesDisciplineCode",
                principalTable: "Disciplines",
                principalColumn: "DisciplineCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_ClassTeacherId",
                table: "Groups",
                column: "ClassTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Disciplines_DisciplineCode",
                table: "Homeworks",
                column: "DisciplineCode",
                principalTable: "Disciplines",
                principalColumn: "DisciplineCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Disciplines_DisciplineCode",
                table: "Lessons",
                column: "DisciplineCode",
                principalTable: "Disciplines",
                principalColumn: "DisciplineCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Students_StudentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Teachers_TeacherId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlMarks_Disciplines_DisciplineCode",
                table: "ControlMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineTeacher_Disciplines_DisciplinesDisciplineCode",
                table: "DisciplineTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_ClassTeacherId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Disciplines_DisciplineCode",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Disciplines_DisciplineCode",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ControlMarks",
                table: "ControlMarks");

            migrationBuilder.DropIndex(
                name: "IX_ControlMarks_DisciplineCode",
                table: "ControlMarks");

            migrationBuilder.DropColumn(
                name: "HighLevel",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "InitialLevel",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "MaxLevel",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "MinLevel",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "SufficientLevel",
                table: "LessonTypes");

            migrationBuilder.RenameColumn(
                name: "VisitationStatus",
                table: "Visitations",
                newName: "visitation_status");

            migrationBuilder.RenameColumn(
                name: "LataFor",
                table: "Visitations",
                newName: "late_for");

            migrationBuilder.RenameColumn(
                name: "DateOfMarking",
                table: "Visitations",
                newName: "date_of_marking");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Users",
                newName: "birthday");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "user_password");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Users",
                newName: "middle_name");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "user_login");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "DateStartWork",
                table: "Teachers",
                newName: "date_start_work");

            migrationBuilder.RenameColumn(
                name: "DateEndWork",
                table: "Teachers",
                newName: "date_end_work");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Students",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Students",
                newName: "student_type");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Students",
                newName: "street_name");

            migrationBuilder.RenameColumn(
                name: "Settlement",
                table: "Students",
                newName: "settlement_name");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Students",
                newName: "region_name");

            migrationBuilder.RenameColumn(
                name: "House",
                table: "Students",
                newName: "house_numder");

            migrationBuilder.RenameColumn(
                name: "Flat",
                table: "Students",
                newName: "flat_numder");

            migrationBuilder.RenameColumn(
                name: "DateOfEntry",
                table: "Students",
                newName: "date_of_entry");

            migrationBuilder.RenameColumn(
                name: "DateOfEnd",
                table: "Students",
                newName: "date_of_end");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Students",
                newName: "area_name");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "MarkTypes",
                newName: "mark_type");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "MarkLessons",
                newName: "mark");

            migrationBuilder.RenameColumn(
                name: "Distinction",
                table: "MarkLessons",
                newName: "distinction");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "MarkHomeworks",
                newName: "mark");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "MarkHomeworks",
                newName: "release_date");

            migrationBuilder.RenameColumn(
                name: "CheckDate",
                table: "MarkHomeworks",
                newName: "check_date");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "LessonTypes",
                newName: "lesson_type_name");

            migrationBuilder.RenameColumn(
                name: "Topic",
                table: "Lessons",
                newName: "lesson_topic");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Lessons",
                newName: "start_time");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Lessons",
                newName: "end_time");

            migrationBuilder.RenameColumn(
                name: "DateOfClasses",
                table: "Lessons",
                newName: "date_of_classes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lessons",
                newName: "lesson_id");

            migrationBuilder.RenameColumn(
                name: "DisciplineCode",
                table: "Lessons",
                newName: "Discipline_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_DisciplineCode",
                table: "Lessons",
                newName: "IX_Lessons_Discipline_Code");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Homeworks",
                newName: "homework_title");

            migrationBuilder.RenameColumn(
                name: "PublicationDate",
                table: "Homeworks",
                newName: "publication_date");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Homeworks",
                newName: "homework_description");

            migrationBuilder.RenameColumn(
                name: "ClosingDate",
                table: "Homeworks",
                newName: "closing_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Homeworks",
                newName: "homework_id");

            migrationBuilder.RenameColumn(
                name: "DisciplineCode",
                table: "Homeworks",
                newName: "Discipline_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_DisciplineCode",
                table: "Homeworks",
                newName: "IX_Homeworks_Discipline_Code");

            migrationBuilder.RenameColumn(
                name: "GroupStatus",
                table: "Groups",
                newName: "group_status");

            migrationBuilder.RenameColumn(
                name: "DateOfCreation",
                table: "Groups",
                newName: "date_of_creation");

            migrationBuilder.RenameColumn(
                name: "ClassTeacherId",
                table: "Groups",
                newName: "teacher_id");

            migrationBuilder.RenameColumn(
                name: "GroupCode",
                table: "Groups",
                newName: "group_code");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_ClassTeacherId",
                table: "Groups",
                newName: "IX_Groups_teacher_id");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Files",
                newName: "file_siez");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Files",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Files",
                newName: "file_id");

            migrationBuilder.RenameColumn(
                name: "DisciplinesDisciplineCode",
                table: "DisciplineTeacher",
                newName: "DisciplinesDiscipline_Code");

            migrationBuilder.RenameColumn(
                name: "DisciplineFullName",
                table: "Disciplines",
                newName: "discipline_full_name");

            migrationBuilder.RenameColumn(
                name: "DisciplineCode",
                table: "Disciplines",
                newName: "discipline_code");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "ControlMarks",
                newName: "mark");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ControlMarks",
                newName: "create_date_mark");

            migrationBuilder.RenameColumn(
                name: "DisciplineCodeCode",
                table: "ControlMarks",
                newName: "Discipline_Code");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Comments",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Comments",
                newName: "teacher_id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Comments",
                newName: "student_id");

            migrationBuilder.RenameColumn(
                name: "DateOfWriting",
                table: "Comments",
                newName: "date_of_writing");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "comment_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TeacherId",
                table: "Comments",
                newName: "IX_Comments_teacher_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_StudentId",
                table: "Comments",
                newName: "IX_Comments_student_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ControlMarks",
                table: "ControlMarks",
                columns: new[] { "StudentId", "TeacherId", "DisciplineCode", "MarkType" });

            migrationBuilder.CreateIndex(
                name: "IX_ControlMarks_Discipline_Code",
                table: "ControlMarks",
                column: "Discipline_Code");

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
                name: "FK_ControlMarks_Disciplines_Discipline_Code",
                table: "ControlMarks",
                column: "Discipline_Code",
                principalTable: "Disciplines",
                principalColumn: "discipline_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineTeacher_Disciplines_DisciplinesDiscipline_Code",
                table: "DisciplineTeacher",
                column: "DisciplinesDiscipline_Code",
                principalTable: "Disciplines",
                principalColumn: "discipline_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_teacher_id",
                table: "Groups",
                column: "teacher_id",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Disciplines_Discipline_Code",
                table: "Homeworks",
                column: "Discipline_Code",
                principalTable: "Disciplines",
                principalColumn: "discipline_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Disciplines_Discipline_Code",
                table: "Lessons",
                column: "Discipline_Code",
                principalTable: "Disciplines",
                principalColumn: "discipline_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
