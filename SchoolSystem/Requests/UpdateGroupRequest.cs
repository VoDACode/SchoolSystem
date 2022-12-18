using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Requests
{
    public class UpdateGroupRequest
    {
        [Required]
        public string GroupCode { get; set; }
        [Required]
        public int ClassTeacherId { get; set; }

        public string? GroupStatus { get; set; }
    }
}
