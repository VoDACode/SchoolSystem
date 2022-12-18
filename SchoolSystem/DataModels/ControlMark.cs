using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class ControlMark
    {
        public string DisciplineCodeCode { get; set; }
        public Discipline Discipline { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string MarkType { get; set; }
        public MarkTypes MarkTypes { get; set; }
        public DateTime CreateDate { get; set; }
        public float Mark { get; set; }
    }
}
