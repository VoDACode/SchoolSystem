using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class MarkTypes
    {
        [Column("mark_type")]
        public string Type { get; set; }
    }
}
