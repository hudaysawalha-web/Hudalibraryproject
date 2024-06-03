using System.ComponentModel.DataAnnotations;

namespace Hudalibraryproject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime CreatedON { get; set; }= DateTime.Now;
        public DateTime UpdatedOn {  get; set; }= DateTime.Now;

        public List<BookCategory> Books { get; set; } = new List<BookCategory> ();


    }
}
