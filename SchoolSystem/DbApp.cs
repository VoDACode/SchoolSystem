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
            addedTest_users();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>().HasKey(p => p.User_Id);
            builder.Entity<Parent>().HasKey(p => p.User_Id);
            builder.Entity<Parent>().HasIndex(u => u.Email).IsUnique();
            builder.Entity<Teacher>().HasKey(p => p.User_Id);
            builder.Entity<Group>().HasKey(p => p.GroupCode);
            builder.Entity<Discipline>().HasKey(p => p.Discipline_Code);
            builder.Entity<MarkHomework>().HasKey(p => new { p.StudentId, p.HomeworkId });
            builder.Entity<LessonType>().HasKey(p => p.TypeName);
            builder.Entity<Visitation>().HasKey(p => new { p.StudentId, p.LessonId });
            builder.Entity<MarkTypes>().HasKey(p => p.Type);
            builder.Entity<ControlMark>().HasKey(p => new { p.StudentId, p.TeacherId, p.DisciplineCode, p.MarkType });
            builder.Entity<MarkLesson>().HasKey(p => new { p.StudentId, p.LessonId });
            base.OnModelCreating(builder);
        }

        private void addedTest_users()
        {
            var random = new Random();
            if (!Users.Any())
            {
                for (int i = 0; i < 120; i++)
                {
                    User user = Users.Add(new User()
                    {
                        Birthday = DateTime.Now - new TimeSpan(random.Next(1000000000)),
                        FirstName = $"FirstName{i}",
                        LastName = $"LastName{i}",
                        MiddleName = random.Next(100) < 60 ? $"MiddleName{i}" : null,
                        Login = $"Login{i}",
                        Password = $"This is password[{i}]",
                        PhoneNumber = random.NextInt64(9999999999999).ToString()
                    }).Entity;
                }
                SaveChanges();
            }
            if (!Parents.Any())
            {
                for (int i = 1; i <= 40; i += 4)
                {
                    User user1 = Users.FirstOrDefault(p => p.Id == i);
                    User user2 = Users.FirstOrDefault(p => p.Id == i + 1);
                    var p1 = Parents.Add(new Parent()
                    {
                        Email = $"parent.1.email.{i}@example.com",
                        User = user1
                    }).Entity;
                    var p2 = Parents.Add(new Parent()
                    {
                        Email = $"parent.2.email.{i + 1}@example.com",
                        User = user2
                    }).Entity;

                    for (int s = 1; s <= 2; s++)
                    {
                        var obj = new Student()
                        {
                            House = random.Next(200).ToString(),
                            Area = $"Area{s}",
                            DateOfEntry = DateTime.Now,
                            Country = "UA",
                            Region = $"Region{s}",
                            Settlement = $"Settlement{s}",
                            Street = $"Street{s}",
                            User = Users.FirstOrDefault(p => p.Id == i + 2 + s)
                        };
                        obj.Parents.Add(p1);
                        obj.Parents.Add(p2);
                        Student student = Students.Add(obj).Entity;
                    }
                }
                SaveChanges();
            }
        }
    }
}
