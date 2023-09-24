using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCommercialAutomation.Models.Classes;
namespace MVCCommercialAutomation.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        Context context = new Context();
        public ActionResult Index()
        {
            var pic = context.Products.ToList();
            return View(pic);
        }
    }
}