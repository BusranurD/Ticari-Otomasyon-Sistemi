using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCommercialAutomation.Models.Classes
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        public bool Checking { get; set; }
        public ICollection<Employes> Employees { get; set; }
    }
}
