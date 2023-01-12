using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DataModels;
using System.Reflection.Metadata;

namespace SchoolSystem.Controllers
{
    [Authorize]
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly DbApp DB;
        public ReportsController(DbApp db)
        {
            DB = db;
        }

        [HttpGet("students-list")]
        public async Task<IActionResult> GetStudentsList(string g)
        {
            var group = await DB.Groups.Include(g => g.ClassTeacher).ThenInclude(p => p.User).FirstOrDefaultAsync(p => p.GroupCode == g);
            if (group == null)
                return NotFound();
            var students = await DB.Students.Include(s => s.User).Where(s => s.Groups.Contains(group)).ToListAsync();
            var tmpPath = Path.Combine(Directory.GetCurrentDirectory(), "doc-templates", $"student-list_{DateTime.Now.Ticks}.docx");

            System.IO.File.Copy(Path.Combine(Directory.GetCurrentDirectory(), "doc-templates", "student-list.docx"), tmpPath);

            try
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(tmpPath, true))
                {
                    string docText = "";
                    using (var stream = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = stream.ReadToEnd();
                        docText = docText.Replace("[CLASS]", group.GroupCode).Replace("[CLASS_TEACHER]", group.ClassTeacher.User.FullName);
                    }

                    using (StreamWriter writer = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        writer.Write(docText);
                    }

                    var table = wordDoc.MainDocumentPart.Document.Body.Descendants<Table>().FirstOrDefault();

                    students.OrderBy(p => p.User.FirstName);
                    int i = 0;
                    foreach (var student in students)
                    {
                        TableRow row = new TableRow();
                        row.Append(
                            new TableCell(new Paragraph(new Run(new Text((++i).ToString())))),
                            new TableCell(new Paragraph(new Run(new Text(student.User.FullName))))
                        );
                        table.Append(row);
                    }
                }

                HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                HttpContext.Response.Headers.Add("Content-Disposition", $"attachment; filename=student-list.docx");
                HttpContext.Response.Headers.Add("Content-Length", new FileInfo(tmpPath).Length.ToString());
                await HttpContext.Response.SendFileAsync(tmpPath);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                System.IO.File.Delete(tmpPath);
            }
        }

        [HttpGet("certificate-of-student")]
        public async Task<IActionResult> GetCertificateOfStudent(int id, string whom)
        {
            var student = await DB.Students.Include(s => s.User).Include(p => p.Groups).FirstOrDefaultAsync(p => p.Id == id);
            if(student == null)
                return NotFound();
            var group = student.Groups.FirstOrDefault();
            if(group == null)
                return BadRequest("Student is not assigned to any group");
            var tmpPath = Path.Combine(Directory.GetCurrentDirectory(), "doc-templates", $"certificate-of-study_{DateTime.Now.Ticks}.docx");

            System.IO.File.Copy(Path.Combine(Directory.GetCurrentDirectory(), "doc-templates", "certificate-of-study.docx"), tmpPath);

            try
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(tmpPath, true))
                {
                    string docText = "";
                    using (var stream = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        int startYear = DateTime.Now.Month < 9 ? DateTime.Now.Year - 1 : DateTime.Now.Year;
                        docText = stream.ReadToEnd();
                        docText = docText.Replace("[CLASS_CODE]", group.GroupCode)
                                            .Replace("[STUDENT_FULL_NAME]", student.User.FullName)
                                            .Replace("[START_YEAR]", startYear.ToString())
                                            .Replace("[END_YEAR]", (startYear + 1).ToString())
                                            .Replace("[WHOM]", whom);
                    }

                    using (StreamWriter writer = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        writer.Write(docText);
                    }
                }

                HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                HttpContext.Response.Headers.Add("Content-Disposition", $"attachment; filename=certificate-of-study.docx");
                HttpContext.Response.Headers.Add("Content-Length", new FileInfo(tmpPath).Length.ToString());
                await HttpContext.Response.SendFileAsync(tmpPath);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                System.IO.File.Delete(tmpPath);
            }
        }
    }
}
