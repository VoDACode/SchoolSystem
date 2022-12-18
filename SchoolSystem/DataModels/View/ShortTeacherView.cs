namespace SchoolSystem.DataModels.View
{
    public class ShortTeacherView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public ShortTeacherView(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
        }
        public ShortTeacherView(Teacher teacher) : this(teacher.User)
        {
        }
    }
}
