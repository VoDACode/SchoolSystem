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
    [Route("api/users/parents")]
    [ApiController]
    public class UsersParentsController : ControllerBase
    {
        private readonly DbApp DB;
        public UsersParentsController(DbApp db)
        {
            DB = db;
            GC.Collect();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetParents(int page = 1, int limit = 10, string? q = "")
        {
            if (limit < 0 || limit > 50)
            {
                return BadRequest(new Response(false, "Limit must be between 0 and 50"));
            }
            await DB.Parents.Include(p => p.User).LoadAsync();
            IQueryable<Parent> query = DB.Parents.AsQueryable();
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(p => p.User.FirstName.Contains(q) || p.User.LastName.Contains(q) || !string.IsNullOrEmpty(p.User.MiddleName) && p.User.MiddleName.Contains(q));
            }
            var count = (int)Math.Ceiling((double)await query.CountAsync() / limit);
            var usersList = await query.Skip((page - 1) * limit).Take(limit).ToListAsync();
            return Ok(new ResponsePage<Parent, ParentView>(true, usersList, count, page));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}")]
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

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
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

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
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


        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}/update-relatives")]
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
    }
}
