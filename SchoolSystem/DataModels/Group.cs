using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Group
    {
        public string GroupCode { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string? GroupStatus { get; set; }

        public Teacher ClassTeacher { get; set; }
        public List<Student>? Students { get; set; } = new();
    }
}
