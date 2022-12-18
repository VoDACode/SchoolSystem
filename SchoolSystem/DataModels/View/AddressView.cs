namespace SchoolSystem.DataModels.View
{
    public class AddressView
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string Settlement { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int? Flat { get; set; }

        public AddressView(Student student)
        {
            Country = student.Country;
            Region = student.Region;
            Area = student.Area;
            Settlement = student.Settlement;
            Street = student.Street;
            House = student.House;
            Flat = student.Flat;
        }
    }
}
