using SchoolSystem.DataModels;

namespace SchoolSystem.Responses
{
    public class ResponseStudent : Response
    {
        public ResponseStudent(bool success, User user) : base(success, "Student model")
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
                dateOfEntry = user.Student.DateOfEntry,
                address = new
                {
                    country = user.Student.Country,
                    region = user.Student.Region,
                    area = user.Student.Area,
                    settlement = user.Student.Settlement,
                    street = user.Student.Street,
                    house = user.Student.House,
                    flat = user.Student.Flat
                },
                parents = user.Student.Parents?.Select(x => new
                {
                    id = x.User.Id,
                    firstname = x.User.FirstName,
                    lastname = x.User.LastName,
                    middlename = x.User.MiddleName,
                    phone = x.User.PhoneNumber,
                    login = x.User.Login,
                    email = x.User.Email
                })
            };
        }
    }
}
