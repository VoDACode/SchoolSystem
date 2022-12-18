using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.DataModels.View;
using SchoolSystem.Responses;
using System.Security.Claims;

namespace SchoolSystem.Controllers.Users
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DbApp DB;
        public UsersController(DbApp db)
        {
            DB = db;
            GC.Collect();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetUsersList(int page = 1, int limit = 10, string? q = "")
        {
            if(limit < 0 || limit > 50)
            {
                return BadRequest(new Response(false, "Limit must be between 0 and 50"));
            }
            // SELECT * FROM Users LIMIT @limit OFFSET (@page - 1) * @limit
            var query = DB.Users.AsQueryable();
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(u => u.FirstName.Contains(q) || u.LastName.Contains(q) || u.MiddleName.Contains(q));
            }
            int totalPages = (int)Math.Ceiling((double)query.Count() / limit);
            var users = query.Skip((page - 1) * limit).Take(limit).OrderBy(u => u.FirstName);

            var usersList = await users.ToListAsync();

            for (int i = 0; i < usersList.Count; i++)
            {
                await usersList[i].InitRoles(DB);
            }
            return Ok(new ResponsePage<User, FullUserInfo>(true, usersList, totalPages, page));
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
    }
}
