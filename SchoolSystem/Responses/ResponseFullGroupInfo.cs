using SchoolSystem.DataModels;
using SchoolSystem.DataModels.View;

namespace SchoolSystem.Responses
{
    public class ResponseFullGroupInfo : Response
    {
        public ResponseFullGroupInfo(bool success, Group group) : base(success, "Group")
        {
            Data = new FullGroupInfo(group);
        }
        public ResponseFullGroupInfo(bool success, IList<Group> group) : base(success, "Group list")
        {
            Data = group.Select(g => new FullGroupInfo(g)).ToList();
        }
    }
}
