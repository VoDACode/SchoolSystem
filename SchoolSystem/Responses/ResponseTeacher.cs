using SchoolSystem.DataModels;

namespace SchoolSystem.Responses
{
    public class ResponseTeacher : Response
    {
        public ResponseTeacher(bool success, User user) : base(success, "Teacher model")
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
                accsesLevel = user.Role,
                dateStartWork = user.Teacher.DateStartWork,
                dateEndWork = user.Teacher.DateEndWork
            };
        }
    }
}
