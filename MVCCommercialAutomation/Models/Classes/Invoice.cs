using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCommercialAutomation.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNumber { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        //sıra no
        public string InvoiceDetailNo { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TaxOffice { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Time { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Recipient { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Vendor { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }

    }
}
