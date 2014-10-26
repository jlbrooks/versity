using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versity.data.Models;

namespace versity.data.DataAccess.EntityFramework
{
    public class VersityDataContext : DbContext
    {
        public VersityDataContext()
            : base("VersityDataContext")
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Hours> Hours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
