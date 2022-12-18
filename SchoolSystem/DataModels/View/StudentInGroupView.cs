namespace SchoolSystem.DataModels.View
{
    public class StudentInGroupView : ShortStudent
    {
        public bool InGroup { get; set; }
        public StudentInGroupView(Student student, bool inGroup) : base(student)
        {
            InGroup = inGroup;
        }
    }
}
