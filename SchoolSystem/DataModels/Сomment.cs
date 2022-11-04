using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Сomment
    {
        [Column("comment_id")]
        public int Id { get; set; }
        [Column("teacher_id")]
        public int TeacherId { get;set; }
        [Column("student_id")]
        public int StudentId { get; set; }
        [Column("comment")]
        [MaxLength(2048)]
        public string Comment { get; set; }
        [Column("date_of_writing")]
        public DateTime DateOfWriting { get; set; }

        public Teacher Teacher { get; set; }
        public Student Student { get; set; }

    }
}
