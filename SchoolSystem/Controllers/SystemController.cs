using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                IsFirstStart = DB.Users.Any();
            }
        }

        [HttpGet("firstStart")]
        public IActionResult FirstStart()
        {
            return Ok(IsFirstStart);
        }
    }
}
