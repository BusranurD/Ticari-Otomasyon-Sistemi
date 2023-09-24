using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCCommercialAutomation.Models.Classes;
namespace MVCCommercialAutomation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Customer customer)
        {
            context.Customers.Add(customer);
            customer.Checking = true;
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {
            var temp = context.Customers.FirstOrDefault(x => x.CustomerMail == customer.CustomerMail && x.Password == customer.Password);
            if(temp != null)
            {
                FormsAuthentication.SetAuthCookie(temp.CustomerMail, false);
                Session["CustomerMail"] = temp.CustomerMail.ToString();
                return RedirectToAction("Index", "Profile");
            }

            return RedirectToAction("Index","Login");
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var temp = context.Admins.FirstOrDefault(x => x.AdminName == admin.AdminName && x.Password == admin.Password);
            if(temp != null)
            {
                FormsAuthentication.SetAuthCookie(temp.AdminName, false);
                Session["AdminName"] = temp.AdminName.ToString();
                return RedirectToAction("Index", "Statistics");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}