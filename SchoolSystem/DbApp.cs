using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;

namespace SchoolSystem
{
    public class DbApp : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Сomment> Comments { get; set; }
        public DbSet<DataModels.File> Files { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<MarkHomework> MarkHomeworks { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<MarkTypes> MarkTypes { get; set; }
        public DbSet<ControlMark> ControlMarks { get; set; }
        public DbSet<MarkLesson> MarkLessons { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Rating> Ratings { get; set; } 
        public DbSet<RatingVoices> RatingVoices { get; set; }
        public DbApp(DbContextOptions<DbApp> options)
            : base(options)
        {
            Database.EnsureCreated();
            //addedTest_users();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Parent>()
                .HasMany(p => p.Students)
                .WithMany(p => p.Parents)
                .UsingEntity(p => p.ToTable("ParentStudent"));

            builder.Entity<User>()
                .HasOne(x => x.Student)
                .WithOne(x => x.User)
                .HasForeignKey<Student>(x => x.Id)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<User>()
                .HasOne(x => x.Teacher)
                .WithOne(x => x.User)
                .HasForeignKey<Teacher>(x => x.Id);
            builder.Entity<User>()
                .HasOne(x => x.Admin)
                .WithOne(x => x.User)
                .HasForeignKey<Admin>(x => x.Id);
            builder.Entity<User>()
                .HasOne(x => x.Parent)
                .WithOne(x => x.User)
                .HasForeignKey<Parent>(x => x.Id);

            builder.Entity<User>().HasKey(p => p.Id);

            builder.Entity<User>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Group>().HasKey(p => p.GroupCode);
            builder.Entity<Discipline>().HasKey(p => p.DisciplineCode);
            builder.Entity<MarkHomework>().HasKey(p => new { p.StudentId, p.HomeworkId });
            builder.Entity<LessonType>().HasKey(p => p.TypeName);
            builder.Entity<Visitation>().HasKey(p => new { p.StudentId, p.LessonId });
            builder.Entity<MarkTypes>().HasKey(p => p.Type);
            builder.Entity<ControlMark>().HasKey(p => new { p.StudentId, p.TeacherId, p.DisciplineCodeCode, p.MarkType });
            builder.Entity<MarkLesson>().HasKey(p => new { p.StudentId, p.LessonId });
            base.OnModelCreating(builder);
        }

    }
}
