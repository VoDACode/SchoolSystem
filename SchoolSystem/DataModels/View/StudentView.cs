namespace SchoolSystem.DataModels.View
{
    public class StudentView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string AccsesLevel { get; set; }
        public DateTime DateOfEntry { get; set; }
        public AddressView Address { get; set; }
        public IEnumerable<ParentView> Parents { get; set; }

        public StudentView(Student student): this(student, false)
        {}

        public StudentView(Student student, bool ignoreParents = false)
        {
            Id = student.User.Id;
            FirstName = student.User.FirstName;
            LastName = student.User.LastName;
            MiddleName = student.User.MiddleName;
            Phone = student.User.PhoneNumber;
            BirthDate = student.User.Birthday;
            Login = student.User.Login;
            Email = student.User.Email;
            AccsesLevel = student.User.Role;
            DateOfEntry = student.DateOfEntry;
            Address = new AddressView(student);
            if (!ignoreParents)
            {
                Parents = student.Parents.Select(p => new ParentView(p, true));
            }
        }

        public StudentView(User user, bool ignoreParents = false)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
            Phone = user.PhoneNumber;
            BirthDate = user.Birthday;
            Login = user.Login;
            Email = user.Email;
            AccsesLevel = user.Role;
            DateOfEntry = user.Student.DateOfEntry;
            Address = new AddressView(user.Student);
            if (!ignoreParents)
            {
                Parents = user.Student.Parents.Select(p => new ParentView(p, true));
            }
        }

        public StudentView(User user) : this(user, false)
        {}
    }
}
