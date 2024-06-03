using System.ComponentModel.DataAnnotations;

namespace Hudalibraryproject.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedON { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }

}
