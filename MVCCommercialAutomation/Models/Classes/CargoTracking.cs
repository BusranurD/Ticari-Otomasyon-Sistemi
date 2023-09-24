﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCCommercialAutomation.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TrackingNo { get; set; }
        public DateTime Date { get; set; }
    }
}