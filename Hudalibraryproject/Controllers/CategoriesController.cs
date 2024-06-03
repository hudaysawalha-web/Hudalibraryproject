using Hudalibraryproject.Data;
using Hudalibraryproject.Models;
using Hudalibraryproject.ViewModel;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM) {

            if(!ModelState.IsValid)
            {
                return View("Create", categoryVM);

            }
            var category = new Category
            {
                Name = categoryVM.Name
            };
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) {
         
            var category = context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();

            }

            var viewModel = new CategoryVM { 
                Id=id,
                Name = category.Name };

            return View("Create", viewModel);
                }
        
        [HttpPost]
      public IActionResult Edit(CategoryVM categoryVM) {
            if (!ModelState.IsValid)
            {
                return View("Create", categoryVM);
            }
            var category = context.Categories.Find(categoryVM.Id);
          if(category is null)
            {
                return NotFound();
            }
          category.Name= categoryVM.Name;
            category.UpdatedOn = DateTime.Now;

        category.Name = categoryVM.Name;
            context.SaveChanges();

            return RedirectToAction("Index");

        }
       
        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id); 
            if (category is null)
            {
                return NotFound();

            }

            var veiwModedl = new CategoryVM
            {
                Id = id,
                Name = category.Name,
                CreatedON = category.CreatedON,
                UpdatedOn = category.UpdatedOn,
            };
            return View(veiwModedl);
        }
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find();
            if (category is null)
            {
                return NotFound();

            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return Ok();
        }
        public IActionResult CheckName(CategoryVM categoryVM)
        {
            var isExsits = context.Categories.Any(Category => Category.Name == categoryVM.Name);
            return Json(!isExsits);
        }



    }
}
