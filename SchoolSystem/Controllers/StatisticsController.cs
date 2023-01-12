using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.DataModels.View;
using SchoolSystem.Responses;

namespace SchoolSystem.Controllers
{
    [Authorize]
    [Route("api/statistics")]
    public class StatisticsController : ControllerBase
    {
        /*
         * SELECT DISTINCT Users.* FROM ParentStudent
INNER JOIN Parents ON ParentStudent.ParentsId = Parents.Id
INNER JOIN Students ON ParentStudent.StudentsId = Students.Id
INNER JOIN Users ON Users.Id = Parents.Id
INNER JOIN GroupStudent ON Students.Id = GroupStudent.StudentsId
WHERE GroupStudent.GroupsGroupCode = N'1-А'

SELECT GroupStudent.GroupsGroupCode, COUNT(*) FROM Parents
INNER JOIN ParentStudent ON ParentStudent.ParentsId = Parents.Id
INNER JOIN GroupStudent ON ParentStudent.StudentsId = GroupStudent.StudentsId
WHERE GroupStudent.GroupsGroupCode LIKE '1%'
GROUP BY GroupStudent.GroupsGroupCode

SELECT GroupStudent.GroupsGroupCode, COUNT(*) FROM Students
INNER JOIN ParentStudent ON ParentStudent.StudentsId = Students.Id
INNER JOIN GroupStudent ON ParentStudent.StudentsId = GroupStudent.StudentsId
WHERE GroupStudent.GroupsGroupCode LIKE '1%'
GROUP BY GroupStudent.GroupsGroupCode
         */
        private readonly DbApp Db;
        public StatisticsController(DbApp db)
        {
            Db = db;
        }

        // кількість вчителів на одного учня
        [HttpGet("teachers")]
        public async Task<IActionResult> GetTeachers()
        {
            // SQL:
            // SELECT COUNT(*) / (SELECT COUNT(*) FROM Students) FROM Teachers
            var teachers = await Db.Teachers.CountAsync();
            var students = await Db.Students.CountAsync();
            var result = new Response(true, "Teachers per student", new
            {
                Teachers = teachers,
                Students = students,
                TeachersPerStudent = (double)teachers / students
            });
            return Ok(result);
        }

        // кількість учнів у паралелі
        [HttpGet("students")]
        public async Task<IActionResult> GetStudents([FromQuery(Name = "group")] int g)
        {
            /*
                SELECT GroupStudent.GroupsGroupCode, COUNT(*) FROM Students
                INNER JOIN ParentStudent ON ParentStudent.StudentsId = Students.Id
                INNER JOIN GroupStudent ON ParentStudent.StudentsId = GroupStudent.StudentsId
                WHERE GroupStudent.GroupsGroupCode LIKE '1%'
                GROUP BY GroupStudent.GroupsGroupCode
             */
            string str = g.ToString();
            var groups = Db.Groups.Where(g => g.GroupCode.StartsWith(str));
            await groups.Include(g => g.Students).LoadAsync();
            
            var list = new List<object>();
            foreach (var group in groups)
            {
                list.Add(new
                {
                    Group = group.GroupCode,
                    Students = group.Students.Count
                });
            }
            return Ok(new Response(true, "Students per group", list));
        }

        // кількість батьків у паралелі
        [HttpGet("parents")]
        public async Task<IActionResult> GetParents([FromQuery(Name = "group")] int g)
        {
            // TO DO: this is not working
            /*
                SELECT GroupStudent.GroupsGroupCode, COUNT(*) FROM Parents
                INNER JOIN ParentStudent ON ParentStudent.ParentsId = Parents.Id
                INNER JOIN GroupStudent ON ParentStudent.StudentsId = GroupStudent.StudentsId
                WHERE GroupStudent.GroupsGroupCode LIKE '1%'
                GROUP BY GroupStudent.GroupsGroupCode
             */

            string str = g.ToString();
            var groups = Db.Groups.Where(g => g.GroupCode.StartsWith(str));
            await groups.Include(g => g.Students).ThenInclude(s => s.Parents).LoadAsync();

            var list = new List<object>();
            foreach (var group in groups)
            {
                list.Add(new
                {
                    Group = group.GroupCode,
                    Parents = group.Students.SelectMany(s => s.Parents).Count()
                });
            }
            return Ok(new Response(true, "Parents per group", list));
        }

        // батьків у класі
        [HttpGet("parentsInGroup")]
        public async Task<IActionResult> GetParentsInGroup([FromQuery(Name = "group")] string g)
        {
            /*
                SELECT DISTINCT Users.* FROM ParentStudent
                INNER JOIN Parents ON ParentStudent.ParentsId = Parents.Id
                INNER JOIN Students ON ParentStudent.StudentsId = Students.Id
                INNER JOIN Users ON Users.Id = Parents.Id
                INNER JOIN GroupStudent ON Students.Id = GroupStudent.StudentsId
                WHERE GroupStudent.GroupsGroupCode = N'@g'
             */

            var groups = Db.Groups.Where(p => p.GroupCode == g);
            if (!await groups.AnyAsync())
            {
                return BadRequest(new Response(false, "Group not found"));
            }

            var group = await groups.FirstAsync();
            var students = Db.Students.Where(p => p.Groups.Contains(group));
            await students.Include(p => p.Parents).ThenInclude(p => p.User).LoadAsync();
            var parentsInGroup = await students.Select(p => p.Parents).ToListAsync();

            var parents = new HashSet<ShortParentView>();
            for (int i = 0; i < parentsInGroup.Count; i++)
            {
                for (int j = 0; j < parentsInGroup[i].Count; j++)
                {
                    if (parents.Any(p => p.Id == parentsInGroup[i][j].Id))
                    {
                        continue;
                    }
                    parents.Add(new ShortParentView(parentsInGroup[i][j]));
                }
            }
            return Ok(new Response(true, "Parents in group", parents));
        }
    }
}
