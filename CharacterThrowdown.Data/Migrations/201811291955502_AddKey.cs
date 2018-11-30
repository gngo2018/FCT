namespace CharacterThrowdown.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Item", "ItemDescription", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Item", "ItemDescription", c => c.String(nullable: false));
        }
    }
}
