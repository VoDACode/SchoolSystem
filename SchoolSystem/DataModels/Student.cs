using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Student
    {
        [Column("student_id")]
        public int User_Id { get; set; }
        [Required]
        [Column("date_of_entry")]
        public DateTime DateOfEntry { get; set; }
        [Column("date_of_end")]
        public DateTime? DateOfEnd { get; set; }
        [MaxLength(128)]
        [Column("student_type")]
        public string? Type { get; set; }
        [Required]
        [MaxLength(64)]
        [Column("country")]
        public string Country { get; set; }
        [Required]
        [MaxLength(64)]
        [Column("region_name")]
        public string Region { get; set; }
        [MaxLength(64)]
        [Column("area_name")]
        public string? Area { get; set; }
        [Required]
        [MaxLength(64)]
        [Column("settlement_name")]
        public string Settlement { get; set; }
        [Required]
        [MaxLength(64)]
        [Column("street_name")]
        public string Street { get; set; }
        [Required]
        [MaxLength(8)]
        [Column("house_numder")]
        public string House { get; set; }
        [Column("flat_numder")]
        public int? Flat { get; set; }

        public List<Parent>? Parents { get; set; } = new();

        public List<Group>? Groups { get; set; } = new();

        public User? User { get; set; }
    }
}
