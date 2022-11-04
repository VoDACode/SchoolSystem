using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Homework
    {
        [Column("homework_id")]
        public int Id { get; set; }
        [Column("discipline_code")]
        public Discipline Discipline { get; set; }
        [Column("group_code")]
        public Group Group { get; set; }
        [Column("publication_date")]
        public DateTime PublicationDate { get; set; }
        [Column("closing_date")]
        public DateTime ClosingDate { get; set; }
        [Column("homework_title")]
        public string Title { get; set; }
        [Column("homework_description")]
        public string Description { get; set; }
        [Column("file_id")]
        public File? File { get; set; }

        public List<MarkHomework>? MarkHomeworks { get; set; } = new();
    }
}
