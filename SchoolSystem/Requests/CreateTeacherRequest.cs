using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Requests
{
    public class CreateTeacherRequest : CreateUserRequest
    {
        [Required]
        public DateTime DateStartWork { get; set; }
    }
}
