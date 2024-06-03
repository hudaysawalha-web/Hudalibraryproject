using BookStore.ViewModel;
using Hudalibraryproject.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hudalibraryproject.Models;
using Hudalibraryproject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hudalibraryproject.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BookController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var books = context.Books
       .Include(book => book.Author)
       .Include(book => book.Categories)
       .ThenInclude(category => category.Category)
       .ToList();

            var bookVms = books.Select(book => new BookVM
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name,
                Publisher = book.Publisher,
                PublishDate = book.PublishDate,
                ImageUrl = book.ImageUrl,
                Categories = book.Categories.Select(c => c.Category.Name).ToList()
            }).ToList();

            return View(bookVms);








        }
        [HttpGet]
        public IActionResult Create()
        {


            var authors = context.Authors.OrderBy(author => author.Name).ToList();
            var authorList = new List<SelectListItem>();
            foreach (var author in authors)
            {

                authorList.Add(new SelectListItem
                {
                    Value = author.Id.ToString(),
                    Text = author.Name,
                });
            }
            var Categories = context.Categories.OrderBy(author => author.Name).ToList();
            var CategoryList = new List<SelectListItem>();
            foreach (var Category in Categories)
            {

                CategoryList.Add(new SelectListItem
                {
                    Value = Category.Id.ToString(),
                    Text = Category.Name,
                });
            }
            var ViewModel = new BookFormVM
            {
                Authors = authorList,
                Categories = CategoryList,
            };
            return View(ViewModel);
        }

        [HttpPost]

        public IActionResult Create(BookFormVM viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            string ImageName = null;
            if (viewModel.ImageUrl != null)
            {
                ImageName = Path.GetFileName(viewModel.ImageUrl.FileName);
                var path = Path.Combine($"{webHostEnvironment.WebRootPath}/img/Book", ImageName);
                var stream = System.IO.File.Create(path);
                viewModel.ImageUrl.CopyTo(stream);
            }


            var book = new Book
            {
                Title = viewModel.Title,
                AuthorId = viewModel.AuthorId,
                Publisher = viewModel.Publisher,
                PublishDate = viewModel.PublishDate,
                Description = viewModel.Description,
                ImageUrl = ImageName,
                Categories = viewModel.SelectedCategories.Select(id => new BookCategory
                {
                    CategoryId = id,
                }).ToList(),
            };
            context.Books.Add(book);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
