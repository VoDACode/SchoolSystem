using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateOfEntry { get; set; }
        public DateTime? DateOfEnd { get; set; }
        [MaxLength(128)]
        public string? Type { get; set; }
        [Required]
        [MaxLength(128)]
        public string Country { get; set; }
        [Required]
        [MaxLength(128)]
        public string Region { get; set; }
        [MaxLength(128)]
        public string? Area { get; set; }
        [Required]
        [MaxLength(128)]
        public string Settlement { get; set; }
        [Required]
        [MaxLength(64)]
        public string Street { get; set; }
        [Required]
        [MaxLength(8)]
        public string House { get; set; }
        public int? Flat { get; set; }

        public IList<Parent> Parents { get; set; } = new List<Parent>();

        public async Task InitUser(DbApp DB)
        {
            User = await DB.Users.SingleAsync(u => u.Id == Id);
        }

        public List<Group>? Groups { get; set; } = new();
        public User User { get; set; }
    }
}
