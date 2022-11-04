using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.Requests;
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
        public async Task<IActionResult> PostLogin(LoginRequest loginRequest)
        {
            var user = await DB.Users.SingleOrDefaultAsync(p => p.Password == loginRequest.Password && p.Login == loginRequest.Login);
            if (user == null)
            {
                return Unauthorized();
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
            return Ok();
        }

        [HttpGet("logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);  
            return LocalRedirect("/");
        }
    }
}
