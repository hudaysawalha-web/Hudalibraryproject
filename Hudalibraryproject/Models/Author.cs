using System.ComponentModel.DataAnnotations;

namespace Hudalibraryproject.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
