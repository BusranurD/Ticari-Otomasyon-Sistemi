using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCommercialAutomation.Models.Classes;

namespace MVCCommercialAutomation.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context context = new Context();
        public ActionResult Index(string temp)
        {
            var cargos = from x in context.Cargos select x;
            if (!string.IsNullOrEmpty(temp))
            {
                cargos = cargos.Where(x => x.TrackingNo.Contains(temp));
            }
            return View(cargos.ToList());
        }
        [HttpGet]
        public ActionResult CargoAdd ()
        {
            Random random = new Random();
            string[] character = { "A", "B", "C", "D" };
            int k1,k2,k3;
            k1 = random.Next(0,4);//{1.2.3}
            k2 = random.Next(0,4);
            k3 = random.Next(0,4);
            int s1,s2,s3;
            s1 = random.Next(100,1000);//3 basamaklı
            s2 = random.Next(10,99);
            s3 = random.Next(10,99);
            string no = s1.ToString() + character[k1] + s2.ToString() + character[k2] + s3.ToString() + character[k3];
            ViewBag.no = no;
            return View();
        }
        [HttpPost]
        public ActionResult CargoAdd(Cargo cargo)
        {
            context.Cargos.Add(cargo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoTracking(string id)
        {
            var tracking = context.CargoTrackings.Where(x => x.TrackingNo == id).ToList();
            return View(tracking);
        }
    }
}