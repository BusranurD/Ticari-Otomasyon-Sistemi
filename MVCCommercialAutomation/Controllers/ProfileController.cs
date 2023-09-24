using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Security;
using MVCCommercialAutomation.Models.Classes;
namespace MVCCommercialAutomation.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var customerMail = (string)Session["CustomerMail"];
            ViewBag.m = customerMail;
            var id = context.Customers.Where(x => x.CustomerMail == customerMail).FirstOrDefault().CustomerID;
            ViewBag.id = id;
            var total = context.SalesTransactions.Where(x => x.CustomerId == id).Count();
            ViewBag.total = total;
            var name = context.Customers.Where(x => x.CustomerMail == customerMail).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.name = name;
            var totalprice = context.SalesTransactions.Where(x => x.CustomerId == id).Select(l => l.TotalPrice).DefaultIfEmpty(0).Sum();
                ViewBag.totalprice = totalprice;

            var amount = context.SalesTransactions.Where(x=> x.CustomerId == id).Select(y => y.Totalpcs).DefaultIfEmpty(0).Sum();
            ViewBag.amount = amount;
            var message = context.Messages.Where(x => x.Recipient == customerMail).ToList();

            var job = context.Customers.Where(x => x.CustomerMail == customerMail).FirstOrDefault().Job;
            ViewBag.job = job;
            var address = context.Customers.Where(x => x.CustomerMail == customerMail).FirstOrDefault().CustomerAddress;
            ViewBag.address = address;
            return View(message);
        }
        public ActionResult Orders()
        {
            var customerMail = (string)Session["CustomerMail"];
            var id = context.Customers.Where(x => x.CustomerMail == customerMail.ToString()).Select(y => y.CustomerID).FirstOrDefault();
            var temp = context.SalesTransactions.Where(x => x.CustomerId == id).ToList();

            return View(temp);
        }
        public PartialViewResult Setting()
        {
            var customerMail = (string)Session["CustomerMail"];
            var id = context.Customers.Where(x => x.CustomerMail == customerMail).FirstOrDefault().CustomerID;
            var customer = context.Customers.Find(id);
            return PartialView("Setting",customer);
        }
        public ActionResult Update(Customer customer)
        {
            var c = context.Customers.Find(customer.CustomerID);
            c.CustomerName = customer.CustomerName;
            c.CustomerSurname = customer.CustomerSurname;
            c.Password = customer.Password;
            c.Job = customer.Job;
            c.CustomerMail = customer.CustomerMail;
            c.CustomerAddress = customer.CustomerAddress;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Cargo(string temp) {
            var cargos = from x in context.Cargos select x;
                cargos = cargos.Where(x => x.TrackingNo.Contains(temp));
            return View(cargos.ToList());
        }
        public ActionResult Detail(string id)
        {
            var tracking = context.CargoTrackings.Where(x => x.TrackingNo == id).ToList();
            return View(tracking);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}