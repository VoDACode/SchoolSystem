using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Lesson
    {
        [Column("lesson_id")]
        public int Id { get; set; }
        [Column("group_code")]
        public Group Group { get; set; }
        [Column("discipline_code")]
        public Discipline Discipline { get; set; }
        [Column("start_time")]
        public TimeSpan StartTime { get; set; }
        [Column("end_time")]
        public TimeSpan EndTime { get; set; }
        [Column("date_of_classes")]
        public DateTime DateOfClasses { get; set; }
        [Column("lesson_topic")]
        public string? Topic { get; set; }
        [Column("lesson_type_name")]
        public LessonType LessonType { get; set; }
    }
}
