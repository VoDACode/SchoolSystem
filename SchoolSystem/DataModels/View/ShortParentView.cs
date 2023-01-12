namespace SchoolSystem.DataModels.View
{
    public class ShortParentView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public ShortParentView(Parent parent)
        {
            Id = parent.Id;
            FirstName = parent.User.FirstName;
            LastName = parent.User.LastName;
            MiddleName = parent.User.MiddleName;
        }
    }
}
