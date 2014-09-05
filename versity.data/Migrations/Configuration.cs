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
            context.Menus.AddOrUpdate(p => p.Name,
                new Menu
                {
                    Name = "Main menu",
                    Active = true,
                    RestaurantID = 1,
                    ID = 1
                });
            context.Items.AddOrUpdate(p => p.Name,
                new Item
                {
                    Name = "Meat",
                    ID = 1,
                    MenuID = 1,
                    Cost = 6.50M,
                    Description = "This is some nice looking meat you got there",
                    Category = Category.Entrees
                });
        }
    }
}
