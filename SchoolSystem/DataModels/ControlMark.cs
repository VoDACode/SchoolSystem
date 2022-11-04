using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class ControlMark
    {
        public string DisciplineCode { get; set; }
        public Discipline Discipline { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string MarkType { get; set; }
        public MarkTypes MarkTypes { get; set; }
        [Column("create_date_mark")]
        public DateTime CreateDate { get; set; }
        [Column("mark")]
        public float Mark { get; set; }
    }
}
