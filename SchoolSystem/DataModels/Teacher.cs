using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class Teacher
    {
        [Column("teacher_id")]
        public int User_Id { get; set; }
        [Column("date_start_work")]
        public DateTime DateStartWork { get; set; }
        [Column("date_end_work")]
        public DateTime DateEndWork { get; set; }
        public User? User { get; set; }
        public List<Discipline>? Disciplines { get; set; } = new();
    }
}
