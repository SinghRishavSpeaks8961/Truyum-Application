using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TruyumApplication.Models
{
    public class TruyumContext:DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public TruyumContext() : base("name=DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}