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
        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }
        [Column("check_date")]
        public DateTime CheckDate { get; set; }
        [Column("mark")]
        public float Mark { get; set; }
    }
}
