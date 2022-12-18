using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace SchoolSystem.DataModels
{
    public enum VisitationStatus
    {
        Attends, Absent, BeingLate
    }
    public class Visitation
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public VisitationStatus? VisitationStatus { get; set; }
        public DateTime DateOfMarking { get; set; }
        public int? LataFor { get; set; }
    }
}
