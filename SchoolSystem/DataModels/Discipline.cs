using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Discipline
    {
        [Column("discipline_code")]
        public string Discipline_Code { get; set; }
        [Column("discipline_full_name")]
        public string DisciplineFullName { get; set; }
        public List<Teacher>? Teachers { get; set; } = new();
    }
}
