using Hudalibraryproject.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hudalibraryproject.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext context)
        {
            this.context = context;
          
        }

        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
    }
}
