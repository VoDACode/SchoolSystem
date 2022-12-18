using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        public List<User>? Users { get; set; } = new();
    }
}
