using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SchoolSystem.DataModels
{
    public class User
    {
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
        public string? MiddleName {get;set; }
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

        public List<File>? Files { get; set; } = new();
    }
}
