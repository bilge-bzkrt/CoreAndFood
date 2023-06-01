using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        Context c = new Context();

        public IActionResult Index()
        {
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {

            return View();

        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(p);
            return RedirectToAction("Index"); //SaveChanges gerek yok! Bunu Repository otomatik sağlayacak.
        }

        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            Category ct = new Category();
            ct.CategoryID = id;
            ct.CategoryName = x.CategoryName;
            ct.CategoryDescription = x.CategoryDescription;
            ct.Status = x.Status;
            return View(ct);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x = categoryRepository.TGet(p.CategoryID);
            x.CategoryName = p.CategoryName;
            x.CategoryDescription = p.CategoryDescription;
            x.Status = true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
