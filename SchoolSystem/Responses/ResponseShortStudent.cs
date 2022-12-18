using SchoolSystem.DataModels;
using SchoolSystem.DataModels.View;

namespace SchoolSystem.Responses
{
    public class ResponseShortStudent : ResponseExtend<Student, ShortStudent>
    {
        public ResponseShortStudent(bool success, string? message, Student data) 
            : base(success, message, data)
        {
        }
        
        public ResponseShortStudent(bool success, string? message, IList<Student> data) 
            : base(success, message, data)
        {
        }
    }
}
