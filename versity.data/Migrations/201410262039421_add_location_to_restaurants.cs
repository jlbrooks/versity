namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_location_to_restaurants : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "RestaurantID", "dbo.Restaurant");
            DropIndex("dbo.Location", new[] { "RestaurantID" });
            DropTable("dbo.Location");
        }
    }
}
