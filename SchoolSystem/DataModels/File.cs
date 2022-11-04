using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.DataModels
{
    public class File
    {
        [Column("file_id")]
        public int Id { get; set; }
        [Column("file_name")]
        public string Name { get; set; }
        [Column("file_siez")]
        public long Size { get; set; }

        public List<User>? Users { get; set; } = new();
    }
}
