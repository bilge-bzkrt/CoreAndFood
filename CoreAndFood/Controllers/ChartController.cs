using CoreAndFood.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1() { proname = "Computer", stock = 150 });
            cs.Add(new Class1() { proname = "Lcd", stock = 150 });
            cs.Add(new Class1() { proname = "Usb Disk", stock = 150 });
            return cs;
        }
    }
}
