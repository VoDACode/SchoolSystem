using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Admin
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
