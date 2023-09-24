using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCommercialAutomation.Models.Classes;
namespace MVCCommercialAutomation.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context context = new Context();
        public ActionResult Index()
        {
            var customers = context.Customers.Where(x => x.Checking == true).ToList();
            return View(customers);
        }
        [HttpGet]
        public ActionResult CustomerAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerAdd(Customer customer)
        {
            customer.Checking = true;
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerDelete(int id)
        {
            var customer = context.Customers.Find(id);
            customer.Checking = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerGet(int id)
        {
            var customer = context.Customers.Find(id);
            return View("CustomerGet", customer);
        }
        public ActionResult CustomerUpdate(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerGet");
            }
            var c = context.Customers.Find(customer.CustomerID);
            c.CustomerName = customer.CustomerName;
            c.CustomerSurname = customer.CustomerSurname;
            c.CustomerMail = customer.CustomerMail;
            c.CustomerAddress = customer.CustomerAddress;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesHistory(int id)
        {
            var sales = context.SalesTransactions.Where(x => x.CustomerId == id).ToList();
            var customer = context.Customers.Where(x => x.CustomerID == id).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.c = customer;
            return View(sales);
        }
    }
}