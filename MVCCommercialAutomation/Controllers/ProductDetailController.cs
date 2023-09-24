using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCommercialAutomation.Models.Classes;

namespace MVCCommercialAutomation.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context context = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.products = context.Products.Where(x => x.ProductID == 1).ToList();
            cs.details = context.Details.Where(y => y.DetailID == 1).ToList();
            return View(cs);
        }
    }
}