namespace SchoolSystem.DataModels.View
{
    public class ParentView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        public IEnumerable<StudentView>? Students { get; set; }

        public ParentView(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
            Phone = user.PhoneNumber;
            Login = user.Login;
            Email = user.Email;
        }

        public ParentView(Parent parent, bool ignoreStudents = true)
        {
            Id = parent.User.Id;
            FirstName = parent.User.FirstName;
            LastName = parent.User.LastName;
            MiddleName = parent.User.MiddleName;
            Phone = parent.User.PhoneNumber;
            Login = parent.User.Login;
            Email = parent.User.Email;
            if (!ignoreStudents)
            {
                Students = parent.Students.Select(s => new StudentView(s, true));
            }
        }
    }
}
