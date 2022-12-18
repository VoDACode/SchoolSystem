namespace SchoolSystem.DataModels.View
{
    public class FullGroupInfo
    {
        public string GroupCode { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string? GroupStatus { get; set; }
        public ShortTeacherView ClassTeacher { get; set; }
        public int[] StudentsIds { get; set; }

        public FullGroupInfo(Group group)
        {
            GroupCode = group.GroupCode;
            DateOfCreation = group.DateOfCreation;
            GroupStatus = group.GroupStatus;
            ClassTeacher = new ShortTeacherView(group.ClassTeacher);
            StudentsIds = group.Students.Select(s => s.Id).ToArray();
        }
    }
}
