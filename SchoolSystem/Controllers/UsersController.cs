using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.Requests;
using SchoolSystem.Responses;
using System;

namespace SchoolSystem.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DbApp DB;
        public UsersController(DbApp db)
        {
            DB = db;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetUsersList()
        {
            //SELECT * FROM Users
            var users = await DB.Users.ToListAsync();
            return Ok(users);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            //SELECT * FROM Users WHERE Id = @id
            var user = await DB.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }
            return Ok(new ResponseUser(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("/students")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest request)
        {
            if (request == null)
            {
                return BadRequest(new Response(false, "Request is empty"));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response(false, "Invalid request"));
            }

            var user = new User()
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                Login = $"{request.LastName.ToLatin()}.{request.FirstName.ToLatin()}_{StringExtensions.RandomString(5)}",
                PhoneNumber = request.Phone,
                Birthday = request.BirthDate,
                Email = request.Email,
                Password = StringExtensions.RandomString(8),
            };

            var student = new Student()
            {
                Area = request.Area,
                Country = request.Country,
                Flat = request.Flat,
                House = request.House,
                Region = request.Region,
                Settlement = request.Settlement,
                Street = request.Street
            };

            /*
             INSERT INTO Users (LastName, FirstName, MiddleName, Login, PhoneNumber, Birthday, Email, Password) 
                VALUES (@LastName, @FirstName, @MiddleName, @Login, @PhoneNumber, @Birthday, @Email, @Password)
            */
            user = (await DB.Users.AddAsync(user)).Entity;

            /*
             INSERT INTO Students (Id, Area, Country, Flat, House, Region, Settlement, Street)
                VALUES (@Id, @Area, @Country, @Flat, @House, @Region, @Settlement, @Street)
            */
            student.User = user;
            await DB.Students.AddAsync(student);
            await DB.SaveChangesAsync();
            return Ok(new ResponseUser(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("/teachers")]
        public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherRequest request)
        {
            if (request == null)
            {
                return BadRequest(new Response(false, "Request is empty"));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response(false, "Invalid request"));
            }

            var user = new User()
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                Login = $"{request.LastName.ToLatin()}.{request.FirstName.ToLatin()}_{StringExtensions.RandomString(5)}",
                PhoneNumber = request.Phone,
                Birthday = request.BirthDate,
                Email = request.Email,
                Password = StringExtensions.RandomString(8),
            };

            var teacher = new Teacher()
            {
                DateStartWork = request.DateStartWork,
            };
            /*
            INSERT INTO Users (LastName, FirstName, MiddleName, Login, PhoneNumber, Birthday, Email, Password) 
               VALUES (@LastName, @FirstName, @MiddleName, @Login, @PhoneNumber, @Birthday, @Email, @Password)
           */
            user = (await DB.Users.AddAsync(user)).Entity;

            teacher.User = user;

            /*
             INSERT INTO Teachers (Id, DateStartWork)
                VALUES (@Id, @DateStartWork)
            */
            await DB.Teachers.AddAsync(teacher);
            await DB.SaveChangesAsync();
            return Ok(new ResponseUser(true, user));
        }


        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            //SELECT * FROM Users WHERE Id = @id
            var user = await DB.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            /*
                DELETE FROM Users
                WHERE Id = @id
            */
            DB.Users.Remove(user);
            await DB.SaveChangesAsync();

            return Ok(new Response(true, "User deleted"));
        }

    }
}
