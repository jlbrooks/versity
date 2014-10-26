namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using versity.data.Models;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<versity.data.DataAccess.EntityFramework.VersityDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(versity.data.DataAccess.EntityFramework.VersityDataContext context)
        {
            context.Restaurants.AddOrUpdate(p => p.Name,
                new Restaurant
                {
                    Name = "Test Restaurant",
                    PhoneNumber = "123-456-7890",
                    Address = "test address, city STATE 97140",
                    ID = 1
                });
        }
    }
}
