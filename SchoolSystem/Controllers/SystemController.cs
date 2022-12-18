using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.Requests;
using SchoolSystem.Responses;

namespace SchoolSystem.Controllers
{
    [Route("api/sys")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private static bool IsFirstStart = false;
        private readonly DbApp DB;

        public SystemController(DbApp db)
        {
            DB = db;
            if (!IsFirstStart)
            {
                IsFirstStart = !DB.Users.Any();
            }
            GC.Collect();
        }

        [HttpGet("firstStart")]
        public IActionResult FirstStart()
        {
            return Ok(IsFirstStart);
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(CreateFirstAdminRequest request)
        {
            if (IsFirstStart)
            {
                return BadRequest(new Response(false, "First start is already done"));
            }
            if (request.Password != request.PasswordConfirm)
            {
                return BadRequest(new Response(false, "Passwords do not match"));
            }
            if (DB.Users.Any())
            {
                return BadRequest(new Response(false, "First start is already done"));
            }
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Birthday = request.BirthDate,
                PhoneNumber = request.Phone,
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
            };
            user = (await DB.Users.AddAsync(user)).Entity;
            var admin = (await DB.Admins.AddAsync(new Admin { User = user })).Entity;
            user.Admin = admin;
            await DB.SaveChangesAsync();

            return Ok(new Response(true, "Admin created"));
        }
    }
}
