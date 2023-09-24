using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCCommercialAutomation.Models.Classes
{
    public class Detail
    {
        public int DetailID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public String ProductName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public String Description { get; set; }
    }
}