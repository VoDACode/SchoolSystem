using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Parent
    {
        public int Id { get; set; }

        public User User { get; set; }

        public async Task InitUser(DbApp DB)
        {
            User = await DB.Users.SingleAsync(u => u.Id == Id);
        }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
