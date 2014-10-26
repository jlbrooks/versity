namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hours",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Open = c.Time(nullable: false, precision: 7),
                        Closed = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MenuID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menu", t => t.MenuID, cascadeDelete: true)
                .Index(t => t.MenuID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hours", "RestaurantID", "dbo.Restaurant");
            DropForeignKey("dbo.Menu", "RestaurantID", "dbo.Restaurant");
            DropForeignKey("dbo.Item", "MenuID", "dbo.Menu");
            DropIndex("dbo.Item", new[] { "MenuID" });
            DropIndex("dbo.Menu", new[] { "RestaurantID" });
            DropIndex("dbo.Hours", new[] { "RestaurantID" });
            DropTable("dbo.Item");
            DropTable("dbo.Menu");
            DropTable("dbo.Restaurant");
            DropTable("dbo.Hours");
        }
    }
}
