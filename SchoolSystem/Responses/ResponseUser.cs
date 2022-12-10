﻿using SchoolSystem.DataModels;

namespace SchoolSystem.Responses
{
    public class ResponseUser : Response
    {
        public ResponseUser(bool success, User user) : base(success, "User model")
        {
            Data = new
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                middlename = user.MiddleName,
                birthDate = user.Birthday,
                phone = user.PhoneNumber,
                login = user.Login,
                email = user.Email,
                accsesLevel = user.Role
            };
        }
    }
}
