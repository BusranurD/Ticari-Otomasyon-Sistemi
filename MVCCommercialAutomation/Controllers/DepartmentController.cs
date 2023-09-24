using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCommercialAutomation.Models.Classes;
namespace MVCCommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context context = new Context();
        public ActionResult Index()
        {
            var departments = context.Deparments.Where(x => x.Checking == true).ToList();
            return View(departments);
        }
        [HttpGet]
        public ActionResult DepartmentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department department)
        {
            context.Deparments.Add(department);
            department.Checking = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDelete(int id)
        {
            var department = context.Deparments.Find(id);
            department.Checking = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentGet(int id)
        {
            var department = context.Deparments.Find(id);
            return View("DepartmentGet", department);
        }
        public ActionResult DepartmentUpdate(Department department)
        {
            var d = context.Deparments.Find(department.DepartmentID);
            d.DepartmentName = department.DepartmentName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var employees = context.Employees.Where(x => x.DepartmentId == id).ToList();
            var department = context.Deparments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = department;
            return View(employees);
        }
        public ActionResult DepartmentEmployesInvoice(int id)
        {
            var sales = context.SalesTransactions.Where(x => x.EmployesId == id).ToList();
            var employes = context.Employees.Where(x => x.EmployesID == id).Select(y => y.EmployesName + " "+ y.EmployesSurname).FirstOrDefault();
            ViewBag.d = employes;
            return View(sales);
        }

    }
}