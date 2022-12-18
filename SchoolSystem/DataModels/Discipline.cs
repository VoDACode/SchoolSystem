using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Discipline
    {
        public string DisciplineCode { get; set; }
        public string DisciplineFullName { get; set; }

        public List<Teacher>? Teachers { get; set; } = new();
    }
}
