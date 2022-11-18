namespace SchoolSystem.Requests
{
    public class CreateStudentRequest : CreateUserRequest
    {
        public DateTime DateOfEntry { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public string? Type { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string? Area { get; set; }
        public string Settlement { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int? Flat { get; set; }
    }
}
