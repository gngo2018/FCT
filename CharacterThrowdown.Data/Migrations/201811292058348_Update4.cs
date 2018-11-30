namespace CharacterThrowdown.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Character", "ItemId", "dbo.Item");
            DropIndex("dbo.Character", new[] { "ItemId" });
            AlterColumn("dbo.Character", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Character", "ItemId");
            AddForeignKey("dbo.Character", "ItemId", "dbo.Item", "ItemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Character", "ItemId", "dbo.Item");
            DropIndex("dbo.Character", new[] { "ItemId" });
            AlterColumn("dbo.Character", "ItemId", c => c.Int());
            CreateIndex("dbo.Character", "ItemId");
            AddForeignKey("dbo.Character", "ItemId", "dbo.Item", "ItemId");
        }
    }
}
