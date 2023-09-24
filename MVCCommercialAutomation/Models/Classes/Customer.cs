using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCommercialAutomation.Models.Classes
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CustomerName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]
        public string CustomerSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CustomerAddress { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CustomerMail { get; set; } 
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Job { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Password { get; set; }

        public bool Checking { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }


    }
}
