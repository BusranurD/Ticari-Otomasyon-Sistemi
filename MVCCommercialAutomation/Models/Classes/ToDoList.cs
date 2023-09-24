using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCCommercialAutomation.Models.Classes
{
    public class ToDoList
    {
        public int TodolistID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Title { get; set; }

        public bool Checking { get; set; }

    }
}