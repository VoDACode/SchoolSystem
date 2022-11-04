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
    [Migration("20221018105634_AddedLesson")]
    partial class AddedLesson
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<int>("StudentsUserId")
                        .HasColumnType("int");

                    b.HasKey("GroupsGroupCode", "StudentsUserId");

                    b.HasIndex("StudentsUserId");

                    b.ToTable("GroupStudent");
                });

            modelBuilder.Entity("ParentStudent", b =>
                {
                    b.Property<int>("ParentsUserId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsUserId")
                        .HasColumnType("int");

                    b.HasKey("ParentsUserId", "StudentsUserId");

                    b.HasIndex("StudentsUserId");

                    b.ToTable("ParentStudent");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Discipline", b =>
                {
                    b.Property<string>("DisciplineCode")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("discipline_code");

                    b.Property<string>("DisciplineFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("discipline_full_name");

                    b.HasKey("DisciplineCode");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("file_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("file_name");

                    b.Property<long>("Size")
                        .HasColumnType("bigint")
                        .HasColumnName("file_siez");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Group", b =>
                {
                    b.Property<string>("GroupCode")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("group_code");

                    b.Property<int>("ClassTeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacher_id");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_creation");

                    b.Property<string>("GroupStatus")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("group_status");

                    b.HasKey("GroupCode");

                    b.HasIndex("ClassTeacherId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Homework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("homework_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("closing_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("homework_description");

                    b.Property<string>("DisciplineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FileId")
                        .HasColumnType("int");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("publication_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("homework_title");

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
                        .HasColumnType("int")
                        .HasColumnName("lesson_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfClasses")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_classes");

                    b.Property<string>("DisciplineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("discipline_code");

                    b.Property<string>("DisciplineCode1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time")
                        .HasColumnName("end_time");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("group_code");

                    b.Property<string>("GroupCode1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LessonTypeTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time")
                        .HasColumnName("start_time");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lesson_topic");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineCode1");

                    b.HasIndex("GroupCode1");

                    b.HasIndex("LessonTypeTypeName");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.LessonType", b =>
                {
                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("lesson_type_name");

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
                        .HasColumnType("datetime2")
                        .HasColumnName("check_date");

                    b.Property<float>("Mark")
                        .HasColumnType("real")
                        .HasColumnName("mark");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("release_date");

                    b.HasKey("StudentId", "HomeworkId");

                    b.HasIndex("AnswerFileId");

                    b.HasIndex("HomeworkId");

                    b.ToTable("MarkHomeworks");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Parent", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("parent_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("parent_email");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Student", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("student_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Area")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("area_name");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("country");

                    b.Property<DateTime?>("DateOfEnd")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_end");

                    b.Property<DateTime>("DateOfEntry")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_entry");

                    b.Property<int?>("Flat")
                        .HasColumnType("int")
                        .HasColumnName("flat_numder");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("house_numder");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("region_name");

                    b.Property<string>("Settlement")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("settlement_name");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("street_name");

                    b.Property<string>("Type")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("student_type");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Teacher", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("teacher_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("DateEndWork")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_end_work");

                    b.Property<DateTime>("DateStartWork")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_start_work");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthday");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("last_name");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("user_login");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("middle_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Сomment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("comment_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasColumnName("comment");

                    b.Property<DateTime>("DateOfWriting")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_writing");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("student_id");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacher_id");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Comments");
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
                        .HasForeignKey("StudentsUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParentStudent", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Parent", null)
                        .WithMany()
                        .HasForeignKey("ParentsUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Group", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.Teacher", "ClassTeacher")
                        .WithMany()
                        .HasForeignKey("ClassTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("DisciplineCode1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.DataModels.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupCode1")
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

            modelBuilder.Entity("SchoolSystem.DataModels.Parent", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Student", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolSystem.DataModels.Teacher", b =>
                {
                    b.HasOne("SchoolSystem.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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
#pragma warning restore 612, 618
        }
    }
}
