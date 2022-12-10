using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.Responses;
using System.Data;

namespace SchoolSystem.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private DbApp DB;
        public SearchController(DbApp db)
        {
            DB = db;
        }

        [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Teacher}")]
        [HttpGet]
        public async Task<IActionResult> Search(string q, int page = 1, int limit = 10)
        {
            if (q == null)
                return BadRequest(new Response(false, "Query is required"));

            var users = await DB.Users.Where(p => p.Login.Contains(q) ||
            p.Email.Contains(q) ||
            p.FirstName.Contains(q) ||
            p.LastName.Contains(q) ||
            p.MiddleName.Contains(q)
            ).Skip((page - 1) * limit).Take(limit).ToListAsync();

            return Ok(new ResponseUsersList(true, users));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("parents")]
        public async Task<IActionResult> GetParents(string? q = null, int top = 10, int skip = 0)
        {
            IQueryable<Parent> users;
            if (string.IsNullOrEmpty(q))
            {
                users = DB.Parents
                    .OrderBy(p => p.User.FirstName)
                    .Skip(skip)
                    .Take(top);
            }
            else
            {
                q = q.ToUpper();
                users = DB.Parents.Where(p => p.User.FirstName.ToUpper().Contains(q) ||
                                                    p.User.LastName.ToUpper().Contains(q) ||
                                                    p.User.MiddleName!.ToUpper().Contains(q))
                    .Skip(skip)
                    .Take(top)
                    .OrderBy(p => p.User.FirstName);
            }
            var res = users.ToList();
            for (int i = 0; i < res.Count(); i++)
            {
                await res[i].InitUser(DB);
            }
            return Ok(new ResponseUsersList(true, res.Select(p => p.User).ToList()));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("students")]
        public async Task<IActionResult> GetStudents(string? q = null, int top = 10, int skip = 0)
        {
            IQueryable<Student> users;
            if (string.IsNullOrEmpty(q))
            {
                users = DB.Students
                    .OrderBy(p => p.User.FirstName)
                    .Skip(skip)
                    .Take(top);
            }
            else
            {
                q = q.ToUpper();
                users = DB.Students.Where(p => p.User.FirstName.ToUpper().Contains(q) ||
                                                    p.User.LastName.ToUpper().Contains(q) ||
                                                    p.User.MiddleName!.ToUpper().Contains(q))
                    .Skip(skip)
                    .Take(top)
                    .OrderBy(p => p.User.FirstName);
            }
            var res = users.ToList();
            for (int i = 0; i < res.Count(); i++)
            {
                await res[i].InitUser(DB);
            }
            return Ok(new ResponseUsersList(true, res.Select(p => p.User).ToList()));
        }
    }
}
