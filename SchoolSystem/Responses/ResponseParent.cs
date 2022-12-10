using SchoolSystem.DataModels;

namespace SchoolSystem.Responses
{
    public class ResponseParent : Response
    {
        public ResponseParent(bool success, User user) : base(success, "Parent model")
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
                children = user.Parent.Students?.Select(x => new
                {
                    id = x.User.Id,
                    firstname = x.User.FirstName,
                    lastname = x.User.LastName,
                    middlename = x.User.MiddleName,
                    phone = x.User.PhoneNumber,
                    login = x.User.Login,
                    email = x.User.Email,
                    dateOfEntry = x.DateOfEntry,
                    dateOfEnd = x.DateOfEnd,
                    address = new
                    {
                        country = x.Country,
                        region = x.Region,
                        area = x.Area,
                        settlement = x.Settlement,
                        street = x.Street,
                        house = x.House,
                        flat = x.Flat
                    },
                })
            };
        }
    }
}
