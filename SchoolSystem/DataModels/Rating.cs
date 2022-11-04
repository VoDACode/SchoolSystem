namespace SchoolSystem.DataModels
{
    public class Rating
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Group> Groups { get; set; } = new();
        public bool CanComment { get; set; }
    }
}
