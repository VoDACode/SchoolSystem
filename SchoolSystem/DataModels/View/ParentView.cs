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
        public DateTime BirthDate { get; set; }

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
            BirthDate = user.Birthday;
        }
        public ParentView(User user, bool ignoreStudents = true) : this(user)
        {
            if (!ignoreStudents)
            {
                Students = user.Parent.Students.Select(s => new StudentView(s, true));
            }
        }

        public ParentView(Parent parent, bool ignoreStudents = true) : this(parent.User)
        {
            if (!ignoreStudents)
            {
                Students = parent.Students.Select(s => new StudentView(s, true));
            }
        }
        public ParentView(Parent parent) : this(parent.User)
        {}
    }
}
