using SchoolSystem.DataModels;

namespace SchoolSystem.Responses
{
    public class ResponseUser : Response
    {
        public ResponseUser(bool success, List<User> users) : base(success, "Users list")
        {
            Data = users.Select(p => 
                new
                {
                    id = p.Id,
                    p.FirstName,
                    p.LastName,
                    p.MiddleName,
                    p.Birthday,
                    p.PhoneNumber,
                    p.Login,
                    p.Email,
                    role = p.Role
                }
            );;
        }
    }
}
