namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using versity.data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<versity.data.DataAccess.EntityFramework.VersityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(versity.data.DataAccess.EntityFramework.VersityDbContext context)
        {
            context.Restaurants.AddOrUpdate(p => p.Name,
                new Restaurant
                {
                    Name = "Test Restaurant",
                    PhoneNumber = "123-456-7890",
                    Address = "101010 Foo Avenue",
                    ID = 1
                });
        }
    }
}
