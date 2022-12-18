namespace SchoolSystem.DataModels.View
{
    public class ShortStudent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string[] Groups { get; set; }
        public ShortStudent(Student student)
        {
            Id = student.Id;
            FirstName = student.User.FirstName;
            LastName = student.User.LastName;
            MiddleName = student.User.MiddleName;
            Groups = student.Groups.Select(g => g.GroupCode).ToArray();
        }
    }
}
