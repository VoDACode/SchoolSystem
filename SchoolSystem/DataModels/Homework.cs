using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Homework
    {
        public int Id { get; set; }
        public Discipline Discipline { get; set; }
        public Group Group { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public File? File { get; set; }

        public List<MarkHomework>? MarkHomeworks { get; set; } = new();
    }
}
