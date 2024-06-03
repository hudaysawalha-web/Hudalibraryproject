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
            var authors = context.Authors.ToList();
            var authorsVm = new List<AuthorVM>();

            foreach( var author in authors)
            {

                var authorVm = new AuthorVM()
                {
                    Id = author.Id,
                    Name = author.Name,
                    CreatedON = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                };
                authorsVm.Add(authorVm);
            }
            return View(authorsVm);
        }

        
        [HttpGet]
        public IActionResult Create(int id)
        {
            var author =  context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,CreatedAt")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(author);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        private bool AuthorExists(int id)
        {
            return context.Authors.Any(e => e.Id == id);
        }
    }


}

