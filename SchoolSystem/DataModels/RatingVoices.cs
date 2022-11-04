namespace SchoolSystem.DataModels
{
    public class RatingVoices
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Rating Rating { get; set; }
        public float Point { get; set; }
        public string? Comment { get; set; }
    }
}
