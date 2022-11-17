using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SchoolSystem.DataModels
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int Id { get; set; }
        [MaxLength(64)]
        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(64)]
        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(64)]
        [Column("middle_name")]
        public string? MiddleName { get; set; }
        [Column("birthday")]
        public DateTime Birthday { get; set; }
        [MaxLength(20)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(64)]
        [Column("user_login")]
        public string Login { get; set; } = string.Empty;
        [EmailAddress]
        public string? Email { get; set; }

        [Column("user_password")]
        public string Password { get; set; } = string.Empty;

        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }
        public Admin? Admin { get; set; }
        public Parent? Parent { get; set; }

        [NotMapped]
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        [NotMapped]
        public string ShortName => $"{LastName} {FirstName[0]}. {MiddleName?[0]}.";
        [NotMapped]
        public string Role => Student != null ? UserRoles.Student : Teacher != null ? UserRoles.Teacher : Admin != null ? UserRoles.Admin : Parent != null ? UserRoles.Parent : UserRoles.Unknown;

        public List<File>? Files { get; set; } = new();
    }
}
