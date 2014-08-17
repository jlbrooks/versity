namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restaurant_dataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurant", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurant", "Name", c => c.String());
        }
    }
}
