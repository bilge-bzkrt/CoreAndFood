using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
        public IActionResult Index(int page=1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page,2)); //sayfalama için 1. adım.
        }

        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.dgr = values;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(Food p)
        {
            foodRepository.TAdd(p);
            return RedirectToAction("Index"); //SaveChanges gerek yok! Bunu Repository otomatik sağlayacak.
        }

        public IActionResult FoodDelete(int id)
        {
            foodRepository.TDelete(new Food { FoodID = id }); //var deger = c.Foods.Find(id);
            return RedirectToAction("Index"); //SaveChanges gerek yok! Bunu Repository otomatik sağlayacak.
        }

        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);

            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.dgr = values;

            Food fd = new Food();
            fd.FoodID = id;
            fd.Name = x.Name;
            fd.Description = x.Description;
            fd.Price = x.Price;
            fd.ImageURL = x.ImageURL;
            fd.Stock = x.Stock;
            fd.CategoryID = x.CategoryID;
            return View(fd);
        }

        [HttpPost]
        public IActionResult FoodUpdate(Food f)
        {
            var x = foodRepository.TGet(f.FoodID);
            x.Name = f.Name;
            x.Description = f.Description;
            x.Price = f.Price;
            x.ImageURL = f.ImageURL;
            x.Stock = f.Stock;
            x.CategoryID = f.CategoryID;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}