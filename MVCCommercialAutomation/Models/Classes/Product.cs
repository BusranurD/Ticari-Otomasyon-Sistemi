using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCommercialAutomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Trademark { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Price { get; set; }
        public bool Checking { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductPic { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }

    }
}
