﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class MarkLesson
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public float Mark { get; set; }
        public string? Distinction { get; set; }
    }
}
