using Hudalibraryproject.Data;
using Hudalibraryproject.Models;
using Hudalibraryproject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Hudalibraryproject.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext context;

        public AuthorsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
          var authorsVm = context.Authors.Select(author => new AuthorVM
		 {
			 Id = author.Id,
			 Name = author.Name,
			 CreatedON = author.CreatedON,
			 UpdatedOn = author.UpdatedOn,
		 }
		 )
		 .ToList();

			return View(authorsVm);
		}
		[HttpGet]

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(AuthorVM authorVM)
		{
			if (!ModelState.IsValid)
			{
				return View("Create", authorVM);
			}
			var author = new Author
			{
				Name = authorVM.Name
			};
			context.Authors.Add(author);

			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var author = context.Authors.Find(id);
			if (author is null)
			{
				return NotFound();

			}
			var viewModel = new AuthorVM
			{
				Id = id,
				Name = author.Name

			};
			return View("Create", viewModel);

		}
		[HttpPost]
		public IActionResult Edit(AuthorVM authorvm)
		{

			if (!ModelState.IsValid)
			{
				return View("Create", authorvm);
			}
			var author = context.Authors.Find(authorvm.Id);
			if (author is null)
			{
				return NotFound();

			}

			author.Name = authorvm.Name;
			author.UpdatedOn = DateTime.Now;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Details(int id)
		{

			var author = context.Authors.Find(id);
			if (author is null)
			{
				return NotFound();
			}
			var viewModel = new AuthorVM
			{
				Id = author.Id,
				Name = author.Name,
				CreatedON = author.CreatedON
				,
				UpdatedOn = author.UpdatedOn
			};
			return View(viewModel);
		}
		public IActionResult Delete(int id)
		{
			var author = context.Authors.Find(id);
			context.Authors.Remove(author);
			context.SaveChanges();
			return RedirectToAction("Index");
		}


	}

}



