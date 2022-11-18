using SchoolSystem.DataModels;

namespace SchoolSystem.Responses
{
    public class ResponseUsersList : Response
    {
        public ResponseUsersList(bool success, List<User> users) : base(success, "Users list")
        {
            Data = users.Select(p => 
                new
                {
                    id = p.Id,
                    name = p.FirstName,
                    surname = p.LastName,
                    middlename = p.MiddleName,
                    phone = p.PhoneNumber,
                    login = p.Login,
                    email = p.Email,
                    accsesLevel = p.Role
                }
            );;
        }
    }
}
