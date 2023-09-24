using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCommercialAutomation.Models.Classes;
namespace MVCCommercialAutomation.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context context = new Context();
        public ActionResult Index()
        {
            var sales = context.SalesTransactions.ToList();
            return View(sales);
        }
        [HttpGet]
        public ActionResult SalesAdd()
        {
            List<SelectListItem> product = (from p in context.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = p.ProductName,
                                                Value = p.ProductID.ToString()
                                            }).ToList();
            ViewBag.product = product;
            List<SelectListItem> customer = (from c in context.Customers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = c.CustomerName + " " +c.CustomerSurname,
                                                Value =c.CustomerID.ToString()
                                            }).ToList();
            ViewBag.customer = customer;
            List<SelectListItem> employes = (from e in context.Employees.ToList()
                                            select new SelectListItem
                                            {
                                                Text = e.EmployesName + " " + e.EmployesSurname,
                                                Value = e.EmployesID.ToString()
                                            }).ToList();
            ViewBag.employes = employes;
            return View();
        }
        [HttpPost]
        public ActionResult SalesAdd(SalesTransaction sales)
        {
            sales.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SalesTransactions.Add(sales);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesGet(int id)
        {
            List<SelectListItem> product = (from p in context.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = p.ProductName,
                                                Value = p.ProductID.ToString()
                                            }).ToList();
            ViewBag.product = product;
            List<SelectListItem> customer = (from c in context.Customers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = c.CustomerName + " " + c.CustomerSurname,
                                                 Value = c.CustomerID.ToString()
                                             }).ToList();
            ViewBag.customer = customer;
            List<SelectListItem> employes = (from e in context.Employees.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = e.EmployesName + " " + e.EmployesSurname,
                                                 Value = e.EmployesID.ToString()
                                             }).ToList();
            ViewBag.employes = employes;
            var sales = context.SalesTransactions.Find(id);
            return View("SalesGet", sales);
        }
        public ActionResult SalesUpdate(SalesTransaction sales)
        {
            var s = context.SalesTransactions.Find(sales.SalesTransactionID);
            s.CustomerId = sales.CustomerId;
            s.Totalpcs = sales.Totalpcs;
            s.Price = sales.Price;
            s.EmployesId = sales.EmployesId;
            s.Date = sales.Date;
            s.TotalPrice = sales.TotalPrice;
            s.ProductId = sales.ProductId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var sales = context.SalesTransactions.Where(x => x.SalesTransactionID == id).ToList();
            return View(sales);

        }
    }
}