using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Requests
{
    public class UpdateUserRequest
    {
        [StringLength(64, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(64, MinimumLength = 2)]
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Login { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
