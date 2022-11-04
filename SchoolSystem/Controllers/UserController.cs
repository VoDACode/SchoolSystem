using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.Requests;
using System;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DbApp DB;
        public UserController(DbApp db)
        {
            DB = db;
        }

        [HttpGet("list")]
        public IActionResult GetList()
        {
            return Ok(DB.Users.ToList());
        }

        [HttpGet("parent/list")]
        public IActionResult GetParentList()
        {
            var parent = DB.Parents.Select(p => new
            {
                p.Email,
                p.User,
                Students = p.Students
            });
            return Ok(parent);
        }
        [HttpGet("student/list")]
        public IActionResult GetStudentList()
        {
            var students = DB.Students.Select(p => new
            {
                p.Flat,
                p.DateOfEntry,
                p.Area,
                p.House,
                p.Region,
                p.Parents,
                p.Street,
                p.DateOfEnd,
                p.Groups,
                p.Settlement
            });
            return Ok(students);
        }

        [HttpGet("student/{parentId}")]
        public IActionResult GeStudentInParent(int parentId)
        {
            var students = DB.Parents.Single(p => p.User_Id == parentId);
            return Ok(students);
        }

        [HttpGet("parent/{studentId}")]
        public IActionResult GetParentInStudent(int studentId)
        {
            var parent = DB.Students.Single(p => p.User_Id == studentId).Parents;
            return Ok(parent);
        }

        [HttpPost]
        public IActionResult PostUser(User data)
        {
            User user = DB.Users.Add(data).Entity;
            DB.SaveChanges();
            return Ok(user);
        }

        [HttpPost("parent")]
        public IActionResult PostParent(PostParentRequest data)
        {
            Parent user = DB.Parents.Add(new Parent()
            {
                Email = data.Email,
                User = DB.Users.Single(p => p.Id == data.Id)
            }).Entity;
            DB.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user = DB.Users.Single(p => p.Id == id);
            var student = DB.Students.SingleOrDefault(p => p.User.Id == id);
            var parent = DB.Parents.SingleOrDefault(p => p.User.Id == id);
            if(student != null)
            {
                student.Parents?.Clear();
                DB.Students.Remove(student);
            }
            if (parent != null)
            {
                parent.Students?.Clear();
                DB.Parents.Remove(parent);
            }
            DB.Users.Remove(user);
            DB.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult PutUser(User data)
        {
            var dbObj = DB.Users.Single(p => p.Id == data.Id);
            dbObj.PhoneNumber = data.PhoneNumber;
            dbObj.LastName = data.LastName;
            dbObj.FirstName = data.FirstName;
            dbObj.MiddleName = data.MiddleName;
            dbObj.Login = data.Login;
            dbObj.Password = data.Password;

            DB.SaveChanges();
            return Ok(dbObj);
        }
    }
}
