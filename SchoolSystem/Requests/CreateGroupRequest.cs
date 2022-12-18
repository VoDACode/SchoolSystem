using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Requests
{
    public class CreateGroupRequest
    {
        [Required]
        public string GroupCode { get; set; }
        [Required]
        public int ClassTeacherId { get; set; }
    }
}
