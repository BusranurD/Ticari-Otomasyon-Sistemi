using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCommercialAutomation.Models.Classes;
namespace MVCCommercialAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context context = new Context();
        public ActionResult Index()
        {
            var invoice = context.Invoices.ToList();
            return View(invoice);
        }
        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceAdd(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceGet(int id)
        {
            var invoice = context.Invoices.Find(id);
            return View("InvoiceGet", invoice);
        }
        public ActionResult InvoiceUpdate(Invoice invoice)
        {
            var i = context.Invoices.Find(invoice.InvoiceID);
            i.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            i.InvoiceDetailNo = invoice.InvoiceDetailNo;
            i.Time = invoice.Time;
            i.Date = invoice.Date;
            i.TaxOffice = invoice.TaxOffice;
            i.Recipient = invoice.Recipient;
            i.Vendor = invoice.Vendor;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var invoice = context.InvoiceItems.Where(x => x.InvoiceId == id).ToList();
            ViewBag.invoice= invoice;
            return View(invoice);
        }
        [HttpGet]
        public ActionResult NewInvoiceItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewInvoiceItem(InvoiceItem invoiceItem)
        {
            context.InvoiceItems.Add(invoiceItem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}