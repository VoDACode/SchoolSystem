using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.Requests;
using SchoolSystem.Responses;

namespace SchoolSystem.Controllers
{
    [Authorize]
    [Route("api/discipline")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {
        private readonly DbApp Db;
        public DisciplinesController(DbApp db)
        {
            Db = db;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var disceplines = await Db.Disciplines.ToArrayAsync();
            return Ok(new Response(true, "List of disceplines", disceplines));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Post(DisciplineRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response(false, "Invalid request"));
            }
            if (await Db.Disciplines.AnyAsync(d => d.DisciplineCode == request.Code))
            {
                return BadRequest(new Response(false, "Discipline with this code already exists"));
            }
            var discepline = new Discipline
            {
                DisciplineCode = request.Code,
                DisciplineFullName = request.Name
            };
            await Db.Disciplines.AddAsync(discepline);
            await Db.SaveChangesAsync();
            return Ok(new Response(true, "Discepline created", discepline));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public async Task<IActionResult> Put(DisciplineRequest request)
        {
            var discepline = await Db.Disciplines.FirstOrDefaultAsync(d => d.DisciplineCode == request.Code);
            if (discepline == null)
            {
                return NotFound(new Response(false, "Discepline not found"));
            }
            discepline.DisciplineFullName = request.Name;
            await Db.SaveChangesAsync();
            return Ok(new Response(true, "Discepline updated", discepline));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(DisciplineRequest request)
        {
            var discepline = await Db.Disciplines.FirstOrDefaultAsync(d => d.DisciplineCode == request.Code);
            if (discepline == null)
            {
                return NotFound(new Response(false, "Discepline not found"));
            }
            Db.Disciplines.Remove(discepline);
            await Db.SaveChangesAsync();
            return Ok(new Response(true, "Discepline deleted", discepline));
        }
    }
}
