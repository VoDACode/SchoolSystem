namespace SchoolSystem.DataModels.View
{
    public class TeacherView : FullUserInfo
    {
        public DateTime DateStartWork { get; set; }
        public DateTime? DateEndWork { get; set; }
        public TeacherView(User user) : base(user)
        {
            DateStartWork = user.Teacher.DateStartWork;
            DateEndWork = user.Teacher.DateEndWork;
        }
        public TeacherView(Teacher teacher) : base(teacher.User)
        {
            DateStartWork = teacher.DateStartWork;
            DateEndWork = teacher.DateEndWork;
        }
    }
}
