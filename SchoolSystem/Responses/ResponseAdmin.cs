using SchoolSystem.DataModels;

namespace SchoolSystem.Responses
{
    public class ResponseAdmin : Response
    {
        public ResponseAdmin(bool success, User user) : base(success, "Admin model")
        {
            Data = new
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                middlename = user.MiddleName,
                phone = user.PhoneNumber,
                birthDate = user.Birthday,
                login = user.Login,
                email = user.Email,
                accsesLevel = user.Role
            };
        }
    }
}
