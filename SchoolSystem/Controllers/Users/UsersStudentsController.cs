using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels.View;
using SchoolSystem.DataModels;
using SchoolSystem.Responses;
using System.Data;
using SchoolSystem.Requests;

namespace SchoolSystem.Controllers.Users
{
    [Route("api/users/students")]
    [ApiController]
    public class UsersStudentsController : ControllerBase
    {
        private readonly DbApp DB;
        public UsersStudentsController(DbApp db)
        {
            DB = db;
            GC.Collect();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetStudents(int page = 1, int limit = 10, string? q = "")
        {
            if (limit < 0 || limit > 50)
            {
                return BadRequest(new Response(false, "Limit must be between 0 and 50"));
            }
            await DB.Students.Include(p => p.User).LoadAsync();
            IQueryable<Student> query = DB.Students.AsQueryable();
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(p => p.User.FirstName.Contains(q) || p.User.LastName.Contains(q) || !string.IsNullOrEmpty(p.User.MiddleName) && p.User.MiddleName.Contains(q));
            }
            var count = (int)Math.Ceiling((double)await query.CountAsync() / limit);
            await query.Include(p => p.Parents).LoadAsync();
            var usersList = await query.Skip((page - 1) * limit).Take(limit).ToListAsync();
            return Ok(new ResponsePage<Student, StudentView>(true, usersList, count, page));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}")]
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

            return Ok(new ResponseExtend<User, StudentView>(true, "Students", user));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
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
        [HttpPut("{id}")]
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
        [HttpPut("{id}/update-relatives")]
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
    }
}
