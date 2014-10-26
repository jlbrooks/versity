namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_categories_to_menu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MenuID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menu", t => t.MenuID, cascadeDelete: true)
                .Index(t => t.MenuID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "MenuID", "dbo.Menu");
            DropIndex("dbo.Category", new[] { "MenuID" });
            DropTable("dbo.Category");
        }
    }
}
