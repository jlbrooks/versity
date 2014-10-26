namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_description_to_item : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "Description");
        }
    }
}
