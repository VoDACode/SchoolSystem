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
        public async Task<IActionResult> PostLogin([FromBody] LoginRequest loginRequest)
        {
            var user = await DB.Users.SingleOrDefaultAsync(p => p.Password == loginRequest.Password &&
                                                                p.Login == loginRequest.Login);
            if (user == null)
            {
                return Unauthorized(new Response(false, "Invalid login or password"));
            }
            await user.InitRoles(DB);
            var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, user.Role)
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
