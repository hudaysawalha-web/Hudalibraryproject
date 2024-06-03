using System.ComponentModel.DataAnnotations;

namespace Hudalibraryproject.ViewModel
{
    public class AuthorFromVM
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage ="the name field can't exceed 50 characters")]
        public string Name { get; set; }

    }
}
