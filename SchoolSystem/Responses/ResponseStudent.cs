using SchoolSystem.DataModels;
using SchoolSystem.DataModels.View;

namespace SchoolSystem.Responses
{
    public class ResponseStudent : Response
    {
        public ResponseStudent(bool success, User user) : base(success, "Student model")
        {
            Data = new StudentView(user);
        }
    }
}
