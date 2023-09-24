using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCommercialAutomation.Models.Classes;

namespace MVCCommercialAutomation.Controllers
{
    public class EmployesController : Controller
    {
        // GET: Employes
        Context context = new Context();
        public ActionResult Index()
        {
            var employees = context.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult EmployesAdd()
        {
            List<SelectListItem> department = (from x in context.Deparments.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmentName,
                                                 Value = x.DepartmentID.ToString()
                                             }).ToList();
            ViewBag.department = department;
            return View();
        }
        [HttpPost]
        public ActionResult EmployesAdd(Employes employes)
        {
            if(Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string ext = Path.GetExtension(Request.Files[0].FileName);
                string temp = "~/pic/" + fileName + ext;
                Request.Files[0].SaveAs(Server.MapPath(temp));
                employes.EmployesPic = "/pic/" + fileName + ext;
            }
            context.Employees.Add(employes);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployesGet(int id)
        {
            List<SelectListItem> department = (from x in context.Deparments.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmentName,
                                                   Value = x.DepartmentID.ToString()
                                               }).ToList();
            ViewBag.department = department;

            var employes = context.Employees.Find(id);
            return View("EmployesGet",employes);
        }
        public ActionResult EmployesUpdate(Employes employes)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string ext = Path.GetExtension(Request.Files[0].FileName);
                string temp = "~/pic/" + fileName + ext;
                Request.Files[0].SaveAs(Server.MapPath(temp));
                employes.EmployesPic = "/pic/" + fileName + ext;
            }
            var e = context.Employees.Find(employes.EmployesID);
            e.EmployesName = employes.EmployesName;
            e.EmployesSurname = employes.EmployesSurname;
            e.EmployesPic = employes.EmployesPic;
            e.DepartmentId = employes.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}