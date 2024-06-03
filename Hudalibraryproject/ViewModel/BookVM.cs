
using System.ComponentModel.DataAnnotations;


namespace Hudalibraryproject.ViewModel
{
	public class BookVM
	{
		public int Id { get; set; }
		public DateTime PublishDate { get; set; }
		public string Title { get; set; } = null!;
		public string Author { get; set; } = null!;
		public string Publisher { get; set; } = null!;
		public string ImageUrl { get; set; }
		public List<string> Categories { get; set; }
	}
}