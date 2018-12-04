namespace CharacterThrowdown.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Battles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Battle",
                c => new
                    {
                        BattleId = c.Int(nullable: false, identity: true),
                        FirstCharacterId = c.Int(nullable: false),
                        SecondCharacterId = c.Int(nullable: false),
                        WinnerCharacterId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        Location = c.String(nullable: false),
                        FirstCharacter_CharacterId = c.Int(),
                        SecondCharacter_CharacterId = c.Int(),
                        WinnerCharacter_CharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.BattleId)
                .ForeignKey("dbo.Character", t => t.FirstCharacter_CharacterId)
                .ForeignKey("dbo.Character", t => t.SecondCharacter_CharacterId)
                .ForeignKey("dbo.Character", t => t.WinnerCharacter_CharacterId)
                .Index(t => t.FirstCharacter_CharacterId)
                .Index(t => t.SecondCharacter_CharacterId)
                .Index(t => t.WinnerCharacter_CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Battle", "WinnerCharacter_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Battle", "SecondCharacter_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Battle", "FirstCharacter_CharacterId", "dbo.Character");
            DropIndex("dbo.Battle", new[] { "WinnerCharacter_CharacterId" });
            DropIndex("dbo.Battle", new[] { "SecondCharacter_CharacterId" });
            DropIndex("dbo.Battle", new[] { "FirstCharacter_CharacterId" });
            DropTable("dbo.Battle");
        }
    }
}
