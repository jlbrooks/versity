namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_address_to_restaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "Address");
        }
    }
}
