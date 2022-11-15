namespace SchoolSystem.DataModels
{
    public class UserClaim
    {
        public string type { get; set; }
        public string value { get; set; }
        public UserClaim(string type, string value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
