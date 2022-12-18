using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Lesson
    {
        public int Id { get; set; }
        public Group Group { get; set; }
        public Discipline Discipline { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime DateOfClasses { get; set; }
        public string? Topic { get; set; }

        public LessonType LessonType { get; set; }
    }
}
