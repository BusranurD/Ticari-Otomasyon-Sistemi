using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCommercialAutomation.Models.Classes;

namespace MVCCommercialAutomation.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
        Context context = new Context();
        public ActionResult Index(string temp /*index tarafındaki isimle aynı olması gerekmekte*/)
        {
            var products = from x in context.Products select x;
            if (!string.IsNullOrEmpty(temp))
            {
                products = products.Where(x => x.ProductName.Contains(temp));
            }
            return View(products.ToList());
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> products = (from x in context.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.prodct = products;
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var product = context.Products.Find(id);
            product.Checking = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductGet(int id)
        {
            List<SelectListItem> products = (from x in context.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.prodct = products;

            var product = context.Products.Find(id);
            return View("ProductGet", product);
        }
        public ActionResult ProductUpdate(Product product)
        {
            var p = context.Products.Find(product.ProductID);
            p.PurchasePrice = product.PurchasePrice;
            p.Checking = product.Checking;
            p.CategoryId = product.CategoryId;
            p.Trademark = product.Trademark;
            p.Price = product.Price;
            p.Stock = product.Stock;
            p.ProductName = product.ProductName;
            p.ProductPic = product.ProductPic;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var product = context.Products.ToList();
            return View(product); 
        }
        [HttpGet]
        public ActionResult Sales(int id)
        {
            ViewBag.id = (context.Products.Find(id)).ProductID;
            List<SelectListItem> employes = (from e in context.Employees.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = e.EmployesName + " " + e.EmployesSurname,
                                                 Value = e.EmployesID.ToString()
                                             }).ToList();
            ViewBag.employes = employes;
            ViewBag.price = (context.Products.Find(id)).Price;
            return View();
        }
        [HttpPost]
        public ActionResult Sales(SalesTransaction sales)
        {
            sales.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SalesTransactions.Add(sales);
            context.SaveChanges();
            return RedirectToAction("Index", "Sales");
        }
    }
}