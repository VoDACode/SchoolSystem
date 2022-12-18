using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Requests
{
    public class StudentsRequest
    {
        [Required]
        public int[] StudentIds { get; set; }
    }
}
