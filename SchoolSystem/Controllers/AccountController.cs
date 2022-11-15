using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.Requests;
using SchoolSystem.Responses;
using System;
using System.Security.Claims;

namespace SchoolSystem.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private DbApp DB;

        public AccountController(DbApp db)
        {
            DB = db;
        }

        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody]LoginRequest loginRequest)
        {
            var user = await DB.Users.SingleOrDefaultAsync(p => p.Password == loginRequest.Password &&
                                                                p.Login == loginRequest.Login);
            if (user == null)
            {
                return Unauthorized(new Response(false, "Invalid login or password"));
            }
            string userRole = "";
            if (DB.Students.Any(p => p.User_Id == user.Id))
                userRole = "Student";
            else if (DB.Admins.Any(p => p.User.Id == user.Id))
                userRole = "Admin";
            else if (DB.Teachers.Any(p => p.User_Id == user.Id))
                userRole = "Teacher";
            else if (DB.Parents.Any(p => p.User_Id == user.Id))
                userRole = "Parent";
            var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, userRole)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
            {
                IsPersistent = loginRequest.RememberLogin
            });
            return Ok(new Response(true, "Login successful"));
        }

        [Authorize]
        [HttpGet("user")]
        public IActionResult GetUser()
        {
            var userClaims = User.Claims.Select(x => new UserClaim(x.Type, x.Value)).ToList();
            return Ok(new Response(true, "User data", userClaims));
        }

        [HttpGet("logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}
