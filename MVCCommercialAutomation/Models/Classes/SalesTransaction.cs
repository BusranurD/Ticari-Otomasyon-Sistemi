using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCommercialAutomation.Models.Classes
{
    public class SalesTransaction
    {
        [Key]
        public int SalesTransactionID { get; set; }
        //product
        // employes
        // customer
        public DateTime Date { get; set; }
        public int Totalpcs { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int EmployesId { get; set; }
        public int CustomerId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Employes Employes { get; set; }
        public virtual Customer Customers{ get; set; }
    }
}
