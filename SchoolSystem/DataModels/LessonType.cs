using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class LessonType
    {
        [Column("lesson_type_name")]
        public string TypeName { get; set; }
    }
}
