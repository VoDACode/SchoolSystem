using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Group
    {
        [Column("group_code")]
        public string GroupCode { get; set; }
        [Column("date_of_creation")]
        public DateTime DateOfCreation { get; set; }
        [Column("group_status")]
        public string? GroupStatus { get; set; }
        [Column("teacher_id")]
        public int ClassTeacherId { get; set; }
        public Teacher ClassTeacher { get; set; }
        public List<Student>? Students { get; set; } = new();
    }
}
