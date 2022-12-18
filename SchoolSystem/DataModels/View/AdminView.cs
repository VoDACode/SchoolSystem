namespace SchoolSystem.DataModels.View
{
    public class AdminView : FullUserInfo
    {
        public AdminView(User user) : base(user)
        {
        }
        public AdminView(Admin user) : base(user.User)
        {
        }
    }
}
