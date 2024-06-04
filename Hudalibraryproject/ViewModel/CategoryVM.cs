using Hudalibraryproject.Models;
using System.ComponentModel.DataAnnotations;

namespace Hudalibraryproject.ViewModel
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required (ErrorMessage= "category name is required")]
        [MaxLength(30, ErrorMessage = "30")]
        public string Name { get; set; } = null!;
        public DateTime CreatedON { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public List<BookCategory> Books { get; set; }= new List<BookCategory>();
    }
}