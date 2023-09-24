using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCommercialAutomation.Models.Classes
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Sender { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Recipient { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Topic { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}