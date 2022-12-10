using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.Requests;
using SchoolSystem.Responses;
using System;
using System.Security.Claims;

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
        public async Task<IActionResult> GetUsersList(int page = 1, int limit = 10)
        {
            // SELECT * FROM Users LIMIT @limit OFFSET (@page - 1) * @limit
            var users = await DB.Users.Skip((page - 1) * limit).Take(limit).ToListAsync();
            for (int i = 0; i < users.Count; i++)
            {
                await users[i].InitRoles(DB);
            }
            return Ok(new ResponseUsersList(true, users));
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
            await user.InitRoles(DB);
            return Ok(new ResponseUser(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}/change-password")]
        public async Task<IActionResult> ChangePassword(int id)
        {
            //SELECT * FROM Users WHERE Id = @id
            var user = await DB.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            // UPDATE Users SET Password = @password WHERE Id = @id
            user.Password = StringExtensions.RandomString(16);
            await DB.SaveChangesAsync();
            return Ok(new ResponseUser(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("student/{id}/update-relatives")]
        public async Task<IActionResult> UpdateRelativesForStudent(int id, [FromBody] RequestUpdateRelatives request)
        {
            //SELECT * FROM Users WHERE Id = @id
            var user = await DB.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Student)
            {
                return BadRequest(new Response(false, "User is not a student"));
            }

            //SELECT * FROM Users WHERE Id = @request.FatherId
            var parents = DB.Parents.Where(p => request.RelativeIDs.Contains(p.Id));

            await DB.Students.Include(p => p.Parents).LoadAsync();

            var parentsList = await parents.ToListAsync();

            for (int i = 0; i < user.Student.Parents.Count; i++)
            {
                if (!request.RelativeIDs.Contains(user.Student.Parents[i].Id))
                {
                    //generate SQL DELETE query
                    //DELETE FROM StudentsParents
                    //WHERE StudentId = @user.Id AND ParentId = @user.Student.Parents[i].Id
                    user.Student.Parents.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < parentsList.Count; i++)
            {
                if (!user.Student.Parents.Any(p => p.Id == parentsList[i].Id))
                {
                    //generate SQL INSERT query
                    //INSERT INTO StudentsParents (StudentId, ParentId) VALUES (@user.Id, @parentsList[i].Id)
                    user.Student.Parents.Add(parentsList[i]);
                }
            }
            await DB.SaveChangesAsync();
            return Ok(new ResponseUser(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("parent/{id}/update-relatives")]
        public async Task<IActionResult> UpdateRelativesForParent(int id, [FromBody] RequestUpdateRelatives request)
        {
            //SELECT * FROM Users WHERE Id = @id
            var user = await DB.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Parent)
            {
                return BadRequest(new Response(false, "User is not a parent"));
            }

            //SELECT * FROM Users WHERE Id = @request.FatherId
            var students = DB.Students.Where(p => request.RelativeIDs.Contains(p.Id));

            await DB.Parents.Include(p => p.Students).LoadAsync();

            var studentsList = await students.ToListAsync();

            for (int i = 0; i < user.Parent.Students.Count; i++)
            {
                if (!request.RelativeIDs.Contains(user.Parent.Students[i].Id))
                {
                    user.Parent.Students.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < studentsList.Count; i++)
            {
                if (!user.Parent.Students.Any(p => p.Id == studentsList[i].Id))
                {
                    user.Parent.Students.Add(studentsList[i]);
                }
            }
            await DB.SaveChangesAsync();
            return Ok(new ResponseUser(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("getPassword/{id}")]
        public async Task<IActionResult> GetUserPassword(int id)
        {
            var user = await DB.Users.SingleOrDefaultAsync(p => p.Id == id);
            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }
            return Ok(new Response(true, "User password", user.Password));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (User.Claims.SingleOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value == id.ToString())
            {
                return BadRequest(new Response(false, "Permission denied"));
            }

            //SELECT * FROM Users WHERE Id = @id
            var user = await DB.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            /*
                DELETE FROM Users
                WHERE Id = @id
            */
            await user.DeleteFromOtherTables(DB);
            DB.Users.Remove(user);
            await DB.SaveChangesAsync();

            return Ok(new Response(true, "User deleted"));
        }

        #region Get
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetAdmin(int id)
        {
            var user = await DB.Users.SingleOrDefaultAsync(p => p.Id == id);

            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Admin)
            {
                return BadRequest(new Response(false, $"This user not admin! It`s a '{user.Role}'"));
            }

            return Ok(new ResponseAdmin(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("teacher/{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var user = await DB.Users.SingleOrDefaultAsync(p => p.Id == id);

            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Teacher)
            {
                return BadRequest(new Response(false, $"This user not teacher! It`s a '{user.Role}'"));
            }

            return Ok(new ResponseTeacher(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var user = await DB.Users.SingleOrDefaultAsync(p => p.Id == id);

            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Student)
            {
                return BadRequest(new Response(false, $"This user not student! It`s a '{user.Role}'"));
            }

            await DB.Users.Where(p => p.Id == id).Include(p => p.Student.Parents).ThenInclude(p => p.User).LoadAsync();

            return Ok(new ResponseStudent(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("parent/{id}")]
        public async Task<IActionResult> GetParent(int id)
        {
            var user = await DB.Users.SingleOrDefaultAsync(p => p.Id == id);

            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Parent)
            {
                return BadRequest(new Response(false, $"This user not parent! It`s a '{user.Role}'"));
            }

            await DB.Users.Where(p => p.Id == id).Include(p => p.Parent.Students).ThenInclude(p => p.User).LoadAsync();

            return Ok(new ResponseParent(true, user));
        }

        #endregion

        #region Posts

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("student")]
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
                Street = request.Street,
                DateOfEntry = request.DateOfEntry
            };

            /*
             INSERT INTO Users (LastName, FirstName, MiddleName, Login, PhoneNumber, Birthday, Email, Password) 
                VALUES (@LastName, @FirstName, @MiddleName, @Login, @PhoneNumber, @Birthday, @Email, @Password)
            */
            user = (await DB.Users.AddAsync(user)).Entity;
            await DB.SaveChangesAsync();
            /*
             INSERT INTO Students (Id, Area, Country, Flat, House, Region, Settlement, Street)
                VALUES (@Id, @Area, @Country, @Flat, @House, @Region, @Settlement, @Street)
            */
            student.User = user;
            student = (await DB.Students.AddAsync(student)).Entity;
            user.Student = student;
            await DB.SaveChangesAsync();
            return Ok(new ResponseUser(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("teacher")]
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
            await DB.SaveChangesAsync();
            teacher.User = user;

            /*
             INSERT INTO Teachers (Id, DateStartWork)
                VALUES (@Id, @DateStartWork)
            */
            teacher = (await DB.Teachers.AddAsync(teacher)).Entity;
            user.Teacher = teacher;
            await DB.SaveChangesAsync();
            return Ok(new ResponseUser(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("parent")]
        public async Task<IActionResult> CreateParent([FromBody] CreateParentRequest request)
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

            var parent = new Parent();
            /*
            INSERT INTO Users (LastName, FirstName, MiddleName, Login, PhoneNumber, Birthday, Email, Password) 
               VALUES (@LastName, @FirstName, @MiddleName, @Login, @PhoneNumber, @Birthday, @Email, @Password)
           */
            user = (await DB.Users.AddAsync(user)).Entity;
            await DB.SaveChangesAsync();
            parent.User = user;

            /*
             INSERT INTO Parents (Id)
                VALUES (@Id)
            */
            parent = (await DB.Parents.AddAsync(parent)).Entity;
            user.Parent = parent;
            await DB.SaveChangesAsync();
            return Ok(new ResponseUser(true, user));
        }

        #endregion

        #region Put
        
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("admin/{id}")]
        public async Task<IActionResult> UpdateAdmin([FromBody] CreateAdminRequest request, int id)
        {
            if (request == null)
            {
                return BadRequest(new Response(false, "Request is empty"));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response(false, "Invalid request"));
            }

            var user = await DB.Users.SingleOrDefaultAsync(p => p.Id == id);

            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Admin)
            {
                return BadRequest(new Response(false, $"This user not admin! It`s a '{user.Role}'"));
            }

            user.LastName = request.LastName;
            user.FirstName = request.FirstName;
            user.MiddleName = request.MiddleName;
            user.PhoneNumber = request.Phone;
            user.Birthday = request.BirthDate;
            user.Email = request.Email;

            await DB.SaveChangesAsync();
            return Ok(new ResponseAdmin(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("teacher/{id}")]
        public async Task<IActionResult> UpdateTeacher([FromBody] CreateTeacherRequest request, int id)
        {
            if (request == null)
            {
                return BadRequest(new Response(false, "Request is empty"));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response(false, "Invalid request"));
            }

            var user = await DB.Users.SingleOrDefaultAsync(p => p.Id == id);

            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Teacher)
            {
                return BadRequest(new Response(false, $"This user not teacher! It`s a '{user.Role}'"));
            }

            user.LastName = request.LastName;
            user.FirstName = request.FirstName;
            user.MiddleName = request.MiddleName;
            user.PhoneNumber = request.Phone;
            user.Birthday = request.BirthDate;
            user.Email = request.Email;

            //UPDATE Teachers SET DateStartWork = @DateStartWork WHERE Id = @Id

            user.Teacher.DateStartWork = request.DateStartWork;

            await DB.SaveChangesAsync();
            return Ok(new ResponseTeacher(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("student/{id}")]
        public async Task<IActionResult> UpdateStudent([FromBody] CreateStudentRequest request, int id)
        {
            if (request == null)
            {
                return BadRequest(new Response(false, "Request is empty"));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response(false, "Invalid request"));
            }

            var user = await DB.Users.SingleOrDefaultAsync(p => p.Id == id);

            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Student)
            {
                return BadRequest(new Response(false, $"This user not student! It`s a '{user.Role}'"));
            }

            user.LastName = request.LastName;
            user.FirstName = request.FirstName;
            user.MiddleName = request.MiddleName;
            user.PhoneNumber = request.Phone;
            user.Birthday = request.BirthDate;
            user.Email = request.Email;
            user.Student.Area = request.Area;
            user.Student.Country = request.Country;
            user.Student.Flat = request.Flat;
            user.Student.House = request.House;
            user.Student.Region = request.Region;
            user.Student.Settlement = request.Settlement;
            user.Student.Street = request.Street;
            user.Student.DateOfEntry = request.DateOfEntry;

            await DB.SaveChangesAsync();
            return Ok(new ResponseStudent(true, user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("parent/{id}")]
        public async Task<IActionResult> UpdateParent([FromBody] CreateParentRequest request, int id)
        {
            if (request == null)
            {
                return BadRequest(new Response(false, "Request is empty"));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response(false, "Invalid request"));
            }

            var user = await DB.Users.SingleOrDefaultAsync(p => p.Id == id);

            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Parent)
            {
                return BadRequest(new Response(false, $"This user not parent! It`s a '{user.Role}'"));
            }

            user.LastName = request.LastName;
            user.FirstName = request.FirstName;
            user.MiddleName = request.MiddleName;
            user.PhoneNumber = request.Phone;
            user.Birthday = request.BirthDate;
            user.Email = request.Email;

            await DB.SaveChangesAsync();
            return Ok(new ResponseParent(true, user));
        }

        #endregion
    }
}
