﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolSystem;

#nullable disable

namespace SchoolSystem.Migrations
{
    [DbContext(typeof(DbApp))]
    [Migration("20221210175708_RemovedUncomfortableNames")]
    partial class RemovedUncomfortableNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DisciplineTeacher", b =>
                {
                    b.Property<string>("DisciplinesDisciplineCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("DisciplinesDisciplineCode", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("DisciplineTeacher");
                });

            modelBuilder.Entity("FileUser", b =>
                {
                    b.Property<int>("FilesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("FilesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("FileUser");
                });

            modelBuilder.Entity("GroupStudent", b =>
                {
                    b.Property<string>("GroupsGroupCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("GroupsGroupCode", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("GroupStudent");
                });

            modelBuilder.Entity("ParentStudent", b =>
                {
                    b.Property<int>("ParentsId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("ParentsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ParentStudent", (string)null);
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Admin", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.ControlMark", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("DisciplineCodeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MarkType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisciplineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Mark")
                        .HasColumnType("real");

                    b.Property<string>("MarkTypesType")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentId", "TeacherId", "DisciplineCodeCode", "MarkType");

                    b.HasIndex("DisciplineCode");

                    b.HasIndex("MarkTypesType");

                    b.HasIndex("TeacherId");

                    b.ToTable("ControlMarks");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Discipline", b =>
                {
                    b.Property<string>("DisciplineCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DisciplineFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DisciplineCode");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Group", b =>
                {
                    b.Property<string>("GroupCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ClassTeacherId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RatingId")
                        .HasColumnType("int");

                    b.HasKey("GroupCode");

                    b.HasIndex("ClassTeacherId");

                    b.HasIndex("RatingId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Homework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisciplineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FileId")
                        .HasColumnType("int");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineCode");

                    b.HasIndex("FileId");

                    b.HasIndex("GroupCode");

                    b.ToTable("Homeworks");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfClasses")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisciplineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LessonTypeTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineCode");

                    b.HasIndex("GroupCode");

                    b.HasIndex("LessonTypeTypeName");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.LessonType", b =>
                {
                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HighLevel")
                        .HasColumnType("int");

                    b.Property<int>("InitialLevel")
                        .HasColumnType("int");

                    b.Property<int>("MaxLevel")
                        .HasColumnType("int");

                    b.Property<int>("MinLevel")
                        .HasColumnType("int");

                    b.Property<int>("SufficientLevel")
                        .HasColumnType("int");

                    b.HasKey("TypeName");

                    b.ToTable("LessonTypes");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.MarkHomework", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("HomeworkId")
                        .HasColumnType("int");

                    b.Property<int>("AnswerFileId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Mark")
                        .HasColumnType("real");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentId", "HomeworkId");

                    b.HasIndex("AnswerFileId");

                    b.HasIndex("HomeworkId");

                    b.ToTable("MarkHomeworks");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.MarkLesson", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("Distinction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Mark")
                        .HasColumnType("real");

                    b.HasKey("StudentId", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("MarkLessons");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.MarkTypes", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Type");

                    b.ToTable("MarkTypes");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Parent", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("CanComment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.RatingVoices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Point")
                        .HasColumnType("real");

                    b.Property<int>("RatingId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RatingId");

                    b.HasIndex("StudentId");

                    b.ToTable("RatingVoices");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Area")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("DateOfEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfEntry")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Flat")
                        .HasColumnType("int");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Settlement")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Type")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateEndWork")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStartWork")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Visitation", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfMarking")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LataFor")
                        .HasColumnType("int");

                    b.Property<int?>("VisitationStatus")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("Visitations");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Сomment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<DateTime>("DateOfWriting")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DisciplineTeacher", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Discipline", null)
                        .WithMany()
                        .HasForeignKey("DisciplinesDisciplineCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FileUser", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.File", null)
                        .WithMany()
                        .HasForeignKey("FilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupStudent", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsGroupCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParentStudent", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Parent", null)
                        .WithMany()
                        .HasForeignKey("ParentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Admin", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("SchoolSystem.DataModels.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.ControlMark", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.MarkTypes", "MarkTypes")
                        .WithMany()
                        .HasForeignKey("MarkTypesType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("MarkTypes");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Group", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Teacher", "ClassTeacher")
                        .WithMany()
                        .HasForeignKey("ClassTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Rating", null)
                        .WithMany("Groups")
                        .HasForeignKey("RatingId");

                    b.Navigation("ClassTeacher");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Homework", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId");

                    b.HasOne("SchoolSystem.DataModels.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("File");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Lesson", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.LessonType", "LessonType")
                        .WithMany()
                        .HasForeignKey("LessonTypeTypeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Group");

                    b.Navigation("LessonType");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.MarkHomework", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.File", "AnswerFile")
                        .WithMany()
                        .HasForeignKey("AnswerFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Homework", "Homework")
                        .WithMany("MarkHomeworks")
                        .HasForeignKey("HomeworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnswerFile");

                    b.Navigation("Homework");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.MarkLesson", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Parent", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.User", "User")
                        .WithOne("Parent")
                        .HasForeignKey("SchoolSystem.DataModels.Parent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Rating", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.RatingVoices", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rating");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Student", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("SchoolSystem.DataModels.Student", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Teacher", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.User", "User")
                        .WithOne("Teacher")
                        .HasForeignKey("SchoolSystem.DataModels.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Visitation", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Сomment", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Homework", b =>
                {
                    b.Navigation("MarkHomeworks");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Rating", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.User", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Parent");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}