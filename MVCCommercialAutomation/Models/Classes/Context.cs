using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVCCommercialAutomation.Models.Classes
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Deparments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Employes> Employees { get; set; }
        public DbSet<Overhead> Overheadses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesTransaction> SalesTransactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<CargoTracking> CargoTrackings { get; set; }
    }
}
