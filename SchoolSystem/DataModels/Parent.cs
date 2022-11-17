using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Parent
    {
        public int Id { get; set; }
        [Column("parent_email")]
        public string Email { get; set; }

        public User User { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}
