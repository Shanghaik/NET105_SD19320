using System.ComponentModel.DataAnnotations;

namespace CRUD_UsingAPI.Models
{
    public class Student
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string  CCCD { get; set; }
        public string Major { get; set; }

    }
}
