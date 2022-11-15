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

        
    }
}
