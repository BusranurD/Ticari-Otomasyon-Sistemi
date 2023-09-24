using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCCommercialAutomation.Models.Classes
{
    public class Cargo
    {
        [Key]
        public int CargoID { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string TrackingNo { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Employes { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Recipient { get; set; }
        public DateTime Date { get; set; }
    }
}