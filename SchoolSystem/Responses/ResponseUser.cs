using SchoolSystem.DataModels;

namespace SchoolSystem.Responses
{
    public class ResponseUser : Response
    {
        public ResponseUser(bool success, User user) : base(success, "User model")
        {
            Data = new
            {
                id = user.Id,
                name = user.FirstName,
                surname = user.LastName,
                middlename = user.MiddleName,
                phone = user.PhoneNumber,
                login = user.Login,
                email = user.Email,
                accsesLevel = user.Role
            };
        }
    }
}
