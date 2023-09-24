using MVCCommercialAutomation.Models.Classes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCommercialAutomation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context context = new Context();
        public ActionResult Index(int page = 1)
        {
            var categories = context.Categories.ToList().ToPagedList(page,4);
            return View(categories);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index"); //yünlendirilecek olan aksiyon seçiliyor
        }
        public ActionResult CategoryDelete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult CategoryGet(int id)
        {
            var category = context.Categories.Find(id);
            return View("CategoryGet", category);
        }
        public ActionResult CategoryUpdate(Category category)
        {
            var c = context.Categories.Find(category.CategoryID);
            c.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}