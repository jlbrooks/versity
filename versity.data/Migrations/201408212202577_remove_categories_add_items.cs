namespace versity.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_categories_add_items : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "MenuID", "dbo.Menu");
            DropIndex("dbo.Category", new[] { "MenuID" });
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MenuID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menu", t => t.MenuID, cascadeDelete: true)
                .Index(t => t.MenuID);
            
            DropTable("dbo.Category");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MenuID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Item", "MenuID", "dbo.Menu");
            DropIndex("dbo.Item", new[] { "MenuID" });
            DropTable("dbo.Item");
            CreateIndex("dbo.Category", "MenuID");
            AddForeignKey("dbo.Category", "MenuID", "dbo.Menu", "ID", cascadeDelete: true);
        }
    }
}
