using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Requests
{
    public class CreateUserRequest : IValidatableObject
    {
        [StringLength(64, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(64, MinimumLength = 2)]
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BirthDate > DateTime.Now)
            {
                yield return new ValidationResult("Birth date cannot be in the future");
            }
        }
    }
}
