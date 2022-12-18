using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using SchoolSystem.DataModels.View;
using SchoolSystem.Requests;
using SchoolSystem.Responses;

namespace SchoolSystem.Controllers
{
    [Authorize]
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly DbApp Db;
        public GroupsController(DbApp db)
        {
            Db = db;
            GC.Collect();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int limit = 10, string? q = "")
        {
            if (limit < 0 || limit > 50)
            {
                return BadRequest(new Response(false, "Limit must be between 0 and 50"));
            }
            IQueryable<Group> groups = Db.Groups;
            if (!string.IsNullOrEmpty(q))
            {
                groups = groups.Where(g => g.GroupCode.Contains(q));
            }
            await groups.Include(g => g.ClassTeacher).Include(p => p.ClassTeacher.User).LoadAsync();
            await groups.Include(g => g.Students).LoadAsync();
            var count = await groups.CountAsync();
            count = (int)Math.Ceiling((double)count / limit);
            var groupsList = await groups.Skip((page - 1) * limit).Take(limit).ToListAsync();
            return Ok(new ResponsePage<Group, FullGroupInfo>(true, groupsList, count, page));
        }

        [Authorize(Roles = $"{UserRoles.Student},{UserRoles.Teacher}")]
        [HttpGet("my")]
        public async Task<IActionResult> GetMy()
        {
            var user = await Db.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(User.Identity.Name));
            if (user == null)
                return NotFound(new Response(false, "User not found"));
            await user.InitRoles(Db);

            if (user.Role == UserRoles.Student)
            {
                var student = await Db.Students.Include(u => u.Groups).FirstOrDefaultAsync(u => u.Id == user.Id);
                return Ok(new ResponseFullGroupInfo(true, student.Groups));
            }
            else if (user.Role == UserRoles.Teacher)
            {
                var groups = await Db.Groups.Where(p => p.ClassTeacher == user.Teacher).ToArrayAsync();
                return Ok(new ResponseFullGroupInfo(true, groups));
            }

            return BadRequest(new Response(false, "Bad request"));
        }

        [Authorize]
        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var groups = Db.Groups.Where(g => g.GroupCode == code);
            if (await groups.CountAsync() == 0)
                return NotFound(new Response(false, "Group not found"));
            await groups.Include(g => g.ClassTeacher).ThenInclude(p => p.User).LoadAsync();
            await groups.Include(g => g.Students).LoadAsync();
            var group = await groups.FirstAsync();
            return Ok(new ResponseFullGroupInfo(true, group));
        }

        [Authorize]
        [HttpGet("{code}/exists")]
        public async Task<IActionResult> Exists(string code)
        {
            var group = await Db.Groups.FirstOrDefaultAsync(g => g.GroupCode == code);
            return Ok(new Response(true, "Group exists", group != null));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGroupRequest request)
        {
            if (request == null)
                return BadRequest(new Response(false, "Group is null"));
            if (!ModelState.IsValid)
                return BadRequest(new Response(false, "Invalid model", ModelState));
            if (!Db.Teachers.Any(p => p.Id == request.ClassTeacherId))
                return BadRequest(new Response(false, "Teacher not found"));

            var group = new Group()
            {
                GroupCode = request.GroupCode,
                DateOfCreation = DateTime.Now,
                GroupStatus = "Свторено.",
                ClassTeacher = await Db.Teachers.FirstOrDefaultAsync(t => t.Id == request.ClassTeacherId)
            };

            group = (await Db.Groups.AddAsync(group)).Entity;
            group.ClassTeacher.User = await Db.Users.FirstOrDefaultAsync(t => t.Id == request.ClassTeacherId);
            await Db.SaveChangesAsync();
            return Ok(new ResponseFullGroupInfo(true, group));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code, [FromBody] UpdateGroupRequest request)
        {
            if (request == null)
                return BadRequest(new Response(false, "Group is null"));
            if (!ModelState.IsValid)
                return BadRequest(new Response(false, "Invalid model", ModelState));
            
            await Db.Groups.Include(g => g.ClassTeacher).LoadAsync();
            var group = await Db.Groups.FirstOrDefaultAsync(g => g.GroupCode == code);
            if (group == null)
                return NotFound(new Response(false, "Group not found"));

            if (!Db.Teachers.Any(p => p.Id == request.ClassTeacherId))
                return BadRequest(new Response(false, "Teacher not found"));

            group.GroupCode = request.GroupCode;
            group.ClassTeacher = await Db.Teachers.FirstOrDefaultAsync(t => t.Id == request.ClassTeacherId);

            if (request.GroupStatus != null)
                group.GroupStatus = request.GroupStatus;
            group.ClassTeacher.User = await Db.Users.FirstOrDefaultAsync(t => t.Id == request.ClassTeacherId);
            await Db.SaveChangesAsync();
            return Ok(new ResponseFullGroupInfo(true, group));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            Db.Groups.Include(g => g.ClassTeacher).Include(p => p.ClassTeacher.User).Load();
            var group = await Db.Groups.FirstOrDefaultAsync(g => g.GroupCode == code);
            if (group == null)
                return NotFound(new Response(false, "Group not found"));
            Db.Groups.Remove(group);
            await Db.SaveChangesAsync();
            return Ok(new ResponseFullGroupInfo(true, group));
        }

        [Authorize]
        [HttpGet("{code}/students")]
        public async Task<IActionResult> GetStudents(string code, int page = 1, int limit = 10, string? q = "", string? display = "this")
        {
            if (limit < 0 || limit > 50)
            {
                return BadRequest(new Response(false, "Limit must be between 0 and 50"));
            }
            var group = await Db.Groups.FirstOrDefaultAsync(g => g.GroupCode == code);
            if (group == null)
                return NotFound(new Response(false, "Group not found"));
            var students = Db.Students.AsQueryable();
            
            await students.Include(s => s.Groups).Include(s => s.User).LoadAsync();

            if (!string.IsNullOrWhiteSpace(q))
            {
                students = students.Where(p => p.User.FirstName.Contains(q) || p.User.LastName.Contains(q) || p.User.MiddleName.Contains(q) || p.User.Email.Contains(q) || p.User.PhoneNumber.Contains(q));
            }

            var list = students.Where(s => s.Groups.Any(g => g.GroupCode == code))
                                .Skip((page - 1) * limit).Take(limit);

            var resulr = new List<Student>();
            resulr.AddRange(list);
            if (display == "all")
            {
                var itemsInClass = await list.CountAsync();
                var tmp = students.Where(s => !s.Groups.Any(g => g.GroupCode == code))
                                .Skip(((page - 1) * (limit - itemsInClass < 0 ? 0 : limit - itemsInClass)))
                                .Take(limit - itemsInClass < 0 ? 0 : limit - itemsInClass);
                if (await tmp.CountAsync() > 0)
                    resulr.AddRange(tmp);
            }

            var count = (int)Math.Ceiling((double)await students.CountAsync() / limit);
            
            var responceList = resulr.Select(s => new StudentInGroupView(s, s.Groups.Any(g => g.GroupCode == code))).ToList();
            return Ok(new ResponsePage<StudentInGroupView>(true, responceList, count, page));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{code}/students")]
        public async Task<IActionResult> AddStudents(string code, [FromBody] StudentsRequest request)
        {
            if (request == null)
                return BadRequest(new Response(false, "Request is null"));
            if (!ModelState.IsValid)
                return BadRequest(new Response(false, "Invalid model", ModelState));

            var groups = Db.Groups.Where(g => g.GroupCode == code);
            if (!await groups.AnyAsync())
                return NotFound(new Response(false, "Group not found"));

            await groups.Include(g => g.Students).LoadAsync();
            await groups.Include(g => g.ClassTeacher).ThenInclude(t => t.User).LoadAsync();

            var group = await groups.FirstOrDefaultAsync();
            var students = group.Students;

            var studentIds = request.StudentIds.ToList();
            for (int i = 0; i < students.Count; i++)
            {
                if (!studentIds.Contains(students[i].Id))
                {
                    group.Students.Remove(students[i]);
                }
            }
            for (int i = 0; i < studentIds.Count; i++)
            {
                if (!students.Any(s => s.Id == studentIds[i]))
                {
                    var student = await Db.Students.FirstOrDefaultAsync(s => s.Id == studentIds[i]);
                    if(student == null)
                        return NotFound(new Response(false, "Student not found"));
                    group.Students.Add(student);
                }
            }

            await Db.SaveChangesAsync();
            return Ok(new ResponseFullGroupInfo(true, group));
        }
    }
}
