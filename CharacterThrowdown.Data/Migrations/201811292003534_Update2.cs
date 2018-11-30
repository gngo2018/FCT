namespace CharacterThrowdown.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "ItemName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "ItemName", c => c.String(nullable: false));
        }
    }
}
