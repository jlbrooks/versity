namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_lat_lng_to_location : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "lat", c => c.Double(nullable: false));
            AddColumn("dbo.Location", "lng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Location", "lng");
            DropColumn("dbo.Location", "lat");
        }
    }
}
