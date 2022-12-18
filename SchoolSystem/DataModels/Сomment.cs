using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Сomment
    {
        public int Id { get; set; }
        public int TeacherId { get;set; }
        public int StudentId { get; set; }
        [MaxLength(2048)]
        public string Comment { get; set; }
        public DateTime DateOfWriting { get; set; }

        public Teacher Teacher { get; set; }
        public Student Student { get; set; }

    }
}
