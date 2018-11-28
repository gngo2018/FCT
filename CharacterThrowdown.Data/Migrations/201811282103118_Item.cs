namespace CharacterThrowdown.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Item : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        ItemDescription = c.String(nullable: false),
                        ItemType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Item");
        }
    }
}
