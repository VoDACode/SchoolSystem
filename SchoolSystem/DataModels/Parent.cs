using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Parent
    {
        [Column("parent_id")]
        public int User_Id { get; set; }
        [Column("parent_email")]
        public string Email { get; set; }
        public User? User { get; set; }

        public List<Student>? Students { get; set; } = new();
    }
}
