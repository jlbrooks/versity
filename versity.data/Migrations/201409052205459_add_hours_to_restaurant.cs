namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_hours_to_restaurant : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hours", "RestaurantID", "dbo.Restaurant");
            DropIndex("dbo.Hours", new[] { "RestaurantID" });
            DropTable("dbo.Hours");
        }
    }
}
