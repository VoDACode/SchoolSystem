using SchoolSystem.DataModels;

namespace SchoolSystem.Responses
{
    public class ResponseUsersList : Response
    {
        public ResponseUsersList(bool success, List<User> users) : base(success, "Users list")
        {
            Data = users.Select(user =>
                new
                {
                    id = user.Id,
                    firstname = user.FirstName,
                    lastname = user.LastName,
                    middlename = user.MiddleName,
                    phone = user.PhoneNumber,
                    login = user.Login,
                    email = user.Email,
                    birthDate = user.Birthday,
                    accsesLevel = user.Role
                }
            );
        }
    }
}
