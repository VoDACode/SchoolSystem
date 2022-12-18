using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class MarkHomework
    {
        public int HomeworkId { get; set; }
        public Homework Homework { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int AnswerFileId { get; set; }
        public File? AnswerFile { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CheckDate { get; set; }
        public float Mark { get; set; }
    }
}
