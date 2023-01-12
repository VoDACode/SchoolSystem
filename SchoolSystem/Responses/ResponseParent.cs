using SchoolSystem.DataModels;
using SchoolSystem.DataModels.View;

namespace SchoolSystem.Responses
{
    public class ResponseParent : Response
    {
        public ResponseParent(bool success, User user) : base(success, "Parent model")
        {
            Data = new ParentView(user, false);
        }
    }
}
