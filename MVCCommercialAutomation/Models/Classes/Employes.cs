using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCommercialAutomation.Models.Classes
{
    public class Employes
    {
        [Key]
        public int EmployesID { get; set; }
        [Display(Name = "Ad")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployesName { get; set; }
        [Display(Name = "Soyad")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployesSurname { get; set; }
        [Display(Name = "Resim")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployesPic { get; set; }
        [Display(Name = "Adres")]
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string EmployesAddress { get; set; }
        [Display(Name = "E-posta")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string EmployesMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Password { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public int DepartmentId { get; set; }
        [Display(Name = "Departman")]
        public virtual Department Department { get; set; }
    }
}
