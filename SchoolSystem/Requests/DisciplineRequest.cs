using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Requests
{
    public class DisciplineRequest
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
