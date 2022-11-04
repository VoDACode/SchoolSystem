namespace SchoolSystem.Requests
{
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
    }
}
