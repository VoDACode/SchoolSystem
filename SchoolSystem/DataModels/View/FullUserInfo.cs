namespace SchoolSystem.DataModels.View
{
    public class FullUserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string AccsesLevel { get; set; }

        public FullUserInfo(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
            BirthDate = user.Birthday;
            Phone = user.PhoneNumber;
            Login = user.Login;
            Email = user.Email;
            AccsesLevel = user.Role;
        }
    }
}
