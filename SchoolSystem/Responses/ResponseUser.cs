using SchoolSystem.DataModels;
using SchoolSystem.DataModels.View;

namespace SchoolSystem.Responses
{
    public class ResponseUser : Response
    {
        public ResponseUser(bool success, User user) : base(success, "User model")
        {
            Data = new FullUserInfo(user);
        }
        public ResponseUser(bool success, IList<User> users) : base(success, "Users list")
        {
            Data = users.Select(user => new FullUserInfo(user));
        }
    }
}
