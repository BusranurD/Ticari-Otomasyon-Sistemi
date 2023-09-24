using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCommercialAutomation.Models.Classes;
namespace MVCCommercialAutomation.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context context = new Context();
        public ActionResult Index()
        {
            var customer = context.Customers.Count().ToString();
            ViewBag.d1 = customer;
            var product = context.Products.Count().ToString();
            ViewBag.d2 = product;
            var employes = context.Employees.Count().ToString();
            ViewBag.d3 = employes;
            var category = context.Categories.Count().ToString();
            ViewBag.d4 = category;
            var stock = context.Products.Sum(x =>x.Stock).ToString();
            ViewBag.d5 = stock;
            var trademark = (from x in context.Products select x.Trademark).Distinct().Count().ToString();
            ViewBag.d6 = trademark;
            // stok sayısı 25 altunda olanlar kritik seviye kabul edilecek
            var temp = context.Products.Count(x => x.Stock <=25).ToString();
            ViewBag.d7 = temp;
            var max = (from x in context.Products orderby x.Price descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = max;
            var min = (from x in context.Products orderby x.Price ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = min;
            var freezer = context.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = freezer;
            var laptop = context.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = laptop;
            var money = context.SalesTransactions.Sum(x => x.TotalPrice).ToString();
            ViewBag.d14 = money;
            DateTime today = DateTime.Today;
            var sales = context.SalesTransactions.Count(x => x.Date == today).ToString();
            ViewBag.d15 = sales;
            var todayM = context.SalesTransactions.Where(x => x.Date == today).Sum(y => (decimal?)y.TotalPrice).ToString();
            ViewBag.d16 = todayM;
            var maxTrade = context.Products.GroupBy(x => x.Trademark).OrderByDescending(z => z.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.d12 = maxTrade;
            var maxSales = context.Products.Where(p=>p.ProductID == (context.SalesTransactions.GroupBy(x => x.ProductId).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select( k => k.ProductName).FirstOrDefault();
            ViewBag.d13 = maxSales;
            return View();
        }

        public ActionResult Tables()
        {
            var cities = from x in context.Customers
                         group x by x.CustomerAddress into city
                         select new Group
                         {
                             City = city.Key,
                             Total = city.Count()
                         };
            ViewBag.d = context.Customers.Count();
            return View(cities.ToList());
        }
        public PartialViewResult Partial()
        {
            var category = from x in context.Products
                            group x by x.Category.CategoryName into t
                            select new CategoryGroup
                            {
                                Category = t.Key,
                                Total = t.Count()
                            };
            ViewBag.d = context.Products.Count();
            return PartialView(category.ToList());
        }
        public PartialViewResult Partial1()
        {
            var employes = from x in context.Employees
                           group x by x.Department.DepartmentName into d
                           select new GroupDepartment
                           {
                               Department = d.Key,
                               Total = d.Count()
                           };
            ViewBag.d = context.Employees.Count();
            return PartialView(employes.ToList());
        }
        public PartialViewResult Partial2()
        {
            var employes = context.Employees.ToList();
            return PartialView(employes);
        }
        public PartialViewResult Partial3()
        {
            var product = context.Products.ToList();
            return PartialView(product);
        }

        public PartialViewResult Partial4()
        {
            var trademark = from x in context.Products
                           group x by x.Trademark into t
                           select new TrademarkGroup
                           {
                               Trademark = t.Key,
                               Total = t.Count()
                           };
            ViewBag.d = context.Products.Count();
            return PartialView(trademark.ToList());
        }
        public PartialViewResult TodoList()
        {
            var list = context.ToDoLists.ToList();
            return PartialView(list);
        }
    }
}