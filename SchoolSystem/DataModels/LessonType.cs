using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class LessonType
    {
        public string TypeName { get; set; }
        public int InitialLevel { get; set; } = 0;
        public int MinLevel { get; set; } = 1;
        public int SufficientLevel { get; set; } = 2;
        public int HighLevel { get; set; } = 3;
        public int MaxLevel { get; set; } = 4;
    }
}
