using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SchoolSystem.DataModels
{
    public class User
    {
        private bool _initRole = false;

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

        public List<File>? Files { get; set; } = new();

        [NotMapped]
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        [NotMapped]
        public string ShortName => $"{LastName} {FirstName[0]}. {MiddleName?[0]}.";
        [NotMapped]
        public string Role => Student != null ? UserRoles.Student : Teacher != null ? UserRoles.Teacher : Admin != null ? UserRoles.Admin : Parent != null ? UserRoles.Parent : UserRoles.Unknown;

        public async Task InitRoles(DbApp db)
        {
            _initRole = true;
            Student = await db.Students.SingleOrDefaultAsync(p => p.Id == Id);
            if (Student != null)
                return;
            Teacher = await db.Teachers.SingleOrDefaultAsync(p => p.Id == Id);
            if (Teacher != null)
                return;
            Admin = await db.Admins.SingleOrDefaultAsync(p => p.Id == Id);
            if (Admin != null)
                return;
            Parent = await db.Parents.SingleOrDefaultAsync(p => p.Id == Id);
        }

        public async Task DeleteFromOtherTables(DbApp db)
        {
            if (!_initRole)
            {
                await InitRoles(db);
            }
            if (Student != null)
            {
                db.Students.Remove(Student);
            }
            else if (Teacher != null)
            {
                db.Teachers.Remove(Teacher);
            }
            else if (Admin != null)
            {
                db.Admins.Remove(Admin);
            }
            else if (Parent != null)
            {
                db.Parents.Remove(Parent);
            }
        }
    }
}
