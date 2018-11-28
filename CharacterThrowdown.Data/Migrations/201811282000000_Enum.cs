namespace CharacterThrowdown.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Character", "CharacterUniverse", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Character", "CharacterUniverse", c => c.String(nullable: false));
        }
    }
}
