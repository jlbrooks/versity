namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_address_from_restaurant : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurant", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurant", "Address", c => c.String());
        }
    }
}
