namespace CharacterThrowdown.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Display : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "CharacterAbility", c => c.String(nullable: false));
            DropColumn("dbo.Character", "CharacterAbillity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Character", "CharacterAbillity", c => c.String(nullable: false));
            DropColumn("dbo.Character", "CharacterAbility");
        }
    }
}
