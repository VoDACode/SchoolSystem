using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.Requests;
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
            var users = await DB.Users.ToListAsync();
            return Ok(users);
        }
        
    }
}
