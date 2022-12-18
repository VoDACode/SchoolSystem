using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels.View;
using SchoolSystem.DataModels;
using SchoolSystem.Requests;
using SchoolSystem.Responses;
using System.Data;

namespace SchoolSystem.Controllers.Users
{
    [Route("api/users/admins")]
    [ApiController]
    public class UsersAdminsController : ControllerBase
    {
        private readonly DbApp DB;
        public UsersAdminsController(DbApp db)
        {
            DB = db;
            GC.Collect();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAdmins(int page = 1, int limit = 10, string? q = "")
        {
            if (limit < 0 || limit > 50)
            {
                return BadRequest(new Response(false, "Limit must be between 0 and 50"));
            }
            await DB.Admins.Include(p => p.User).LoadAsync();
            IQueryable<Admin> query = DB.Admins.AsQueryable();
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(p => p.User.FirstName.Contains(q) || p.User.LastName.Contains(q) || !string.IsNullOrEmpty(p.User.MiddleName) && p.User.MiddleName.Contains(q));
            }
            var count = (int)Math.Ceiling((double)await query.CountAsync() / limit);
            var usersList = await query.Skip((page - 1) * limit).Take(limit).ToListAsync();
            return Ok(new ResponsePage<Admin, AdminView>(true, usersList, count, page));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
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
    }
}
