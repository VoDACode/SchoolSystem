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
    [Route("api/users/teachers")]
    [ApiController]
    public class UsersTeachersController : ControllerBase
    {
        private readonly DbApp DB;
        public UsersTeachersController(DbApp db)
        {
            DB = db;
            GC.Collect();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetTeachers(int page = 1, int limit = 10, string? q = "")
        {
            if (limit < 0 || limit > 50)
            {
                return BadRequest(new Response(false, "Limit must be between 0 and 50"));
            }
            await DB.Teachers.Include(p => p.User).LoadAsync();
            IQueryable<Teacher> query = DB.Teachers.AsQueryable();
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(p => p.User.FirstName.Contains(q) || p.User.LastName.Contains(q) || !string.IsNullOrEmpty(p.User.MiddleName) && p.User.MiddleName.Contains(q));
            }
            var count = (int)Math.Ceiling((double)await query.CountAsync() / limit);
            var usersList = await query.Skip((page - 1) * limit).Take(limit).ToListAsync();
            return Ok(new ResponsePage<Teacher, TeacherView>(true, usersList, count, page));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}")]
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
        [HttpGet("{id}/disciplines")]
        public async Task<IActionResult> GetTeacherDisciplines(int id)
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

            await DB.Teachers.Include(p => p.Disciplines).LoadAsync();

            return Ok(new Response(true, "Disciplines list", user.Teacher.Disciplines));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
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
        [HttpPut("{id}")]
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
        [HttpPut("{id}/disciplines")]
        public async Task<IActionResult> UpdateDisciplinesForTeacher(int id)
        {
            var user = await DB.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new Response(false, "User not found"));
            }

            await user.InitRoles(DB);

            if (user.Role != UserRoles.Teacher)
            {
                return BadRequest(new Response(false, $"This user not teacher! It`s a '{user.Role}'"));
            }

            await DB.SaveChangesAsync();
            return Ok(new ResponseUser(true, user));
        }
    }
}
