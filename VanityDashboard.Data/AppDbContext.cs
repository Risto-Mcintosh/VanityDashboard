using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) {
           
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Mirror> Mirrors { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<BaseMaterial> BaseMaterials { get; set; }
        public DbSet<KanbanColumn> KanbanColumns { get; set; }
        public DbSet<KanbanColumnOrder> KanbanColumnOrder { get; set; }

    }
}
