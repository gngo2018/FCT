namespace CharacterThrowdown.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bracket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bracket",
                c => new
                    {
                        BracketId = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        TournamentName = c.String(nullable: false),
                        FirstCharacterEightId = c.Int(nullable: false),
                        SecondCharacterEightId = c.Int(nullable: false),
                        FirstEightWinnerId = c.Int(nullable: false),
                        ThirdCharacterEightId = c.Int(nullable: false),
                        FourthCharacterEightId = c.Int(nullable: false),
                        SecondEightWinnerId = c.Int(nullable: false),
                        FifthCharacterEightId = c.Int(nullable: false),
                        SixthCharacterEightId = c.Int(nullable: false),
                        ThirdEightWinnerId = c.Int(nullable: false),
                        SeventhCharacterEightId = c.Int(nullable: false),
                        EighthCharacterEightId = c.Int(nullable: false),
                        FourthEightWinnerId = c.Int(nullable: false),
                        FirstCharacterFourId = c.Int(nullable: false),
                        SecondCharacterFourId = c.Int(nullable: false),
                        FirstFourWinnerId = c.Int(nullable: false),
                        ThirdCharacterFourId = c.Int(nullable: false),
                        FourthCharacterFourId = c.Int(nullable: false),
                        SecondFourWinnerId = c.Int(nullable: false),
                        FirstCharacterFinalId = c.Int(nullable: false),
                        SecondCharacterFinalId = c.Int(nullable: false),
                        FinalWinnerId = c.Int(nullable: false),
                        EighthCharacterEight_CharacterId = c.Int(),
                        FifthCharacterEight_CharacterId = c.Int(),
                        FinalWinner_CharacterId = c.Int(),
                        FirstCharacterEight_CharacterId = c.Int(),
                        FirstCharacterFinal_CharacterId = c.Int(),
                        FirstCharacterFour_CharacterId = c.Int(),
                        FirstEightWinner_CharacterId = c.Int(),
                        FirstFourWinner_CharacterId = c.Int(),
                        FourthCharacterEight_CharacterId = c.Int(),
                        FourthCharacterFour_CharacterId = c.Int(),
                        FourthEightWinner_CharacterId = c.Int(),
                        SecondCharacterEight_CharacterId = c.Int(),
                        SecondCharacterFinal_CharacterId = c.Int(),
                        SecondCharacterFour_CharacterId = c.Int(),
                        SecondEightWinner_CharacterId = c.Int(),
                        SecondFourWinner_CharacterId = c.Int(),
                        SeventhCharacterEight_CharacterId = c.Int(),
                        SixthCharacterEight_CharacterId = c.Int(),
                        ThirdCharacterEight_CharacterId = c.Int(),
                        ThirdCharacterFour_CharacterId = c.Int(),
                        ThirdEightWinner_CharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.BracketId)
                .ForeignKey("dbo.Character", t => t.EighthCharacterEight_CharacterId)
                .ForeignKey("dbo.Character", t => t.FifthCharacterEight_CharacterId)
                .ForeignKey("dbo.Character", t => t.FinalWinner_CharacterId)
                .ForeignKey("dbo.Character", t => t.FirstCharacterEight_CharacterId)
                .ForeignKey("dbo.Character", t => t.FirstCharacterFinal_CharacterId)
                .ForeignKey("dbo.Character", t => t.FirstCharacterFour_CharacterId)
                .ForeignKey("dbo.Character", t => t.FirstEightWinner_CharacterId)
                .ForeignKey("dbo.Character", t => t.FirstFourWinner_CharacterId)
                .ForeignKey("dbo.Character", t => t.FourthCharacterEight_CharacterId)
                .ForeignKey("dbo.Character", t => t.FourthCharacterFour_CharacterId)
                .ForeignKey("dbo.Character", t => t.FourthEightWinner_CharacterId)
                .ForeignKey("dbo.Character", t => t.SecondCharacterEight_CharacterId)
                .ForeignKey("dbo.Character", t => t.SecondCharacterFinal_CharacterId)
                .ForeignKey("dbo.Character", t => t.SecondCharacterFour_CharacterId)
                .ForeignKey("dbo.Character", t => t.SecondEightWinner_CharacterId)
                .ForeignKey("dbo.Character", t => t.SecondFourWinner_CharacterId)
                .ForeignKey("dbo.Character", t => t.SeventhCharacterEight_CharacterId)
                .ForeignKey("dbo.Character", t => t.SixthCharacterEight_CharacterId)
                .ForeignKey("dbo.Character", t => t.ThirdCharacterEight_CharacterId)
                .ForeignKey("dbo.Character", t => t.ThirdCharacterFour_CharacterId)
                .ForeignKey("dbo.Character", t => t.ThirdEightWinner_CharacterId)
                .Index(t => t.EighthCharacterEight_CharacterId)
                .Index(t => t.FifthCharacterEight_CharacterId)
                .Index(t => t.FinalWinner_CharacterId)
                .Index(t => t.FirstCharacterEight_CharacterId)
                .Index(t => t.FirstCharacterFinal_CharacterId)
                .Index(t => t.FirstCharacterFour_CharacterId)
                .Index(t => t.FirstEightWinner_CharacterId)
                .Index(t => t.FirstFourWinner_CharacterId)
                .Index(t => t.FourthCharacterEight_CharacterId)
                .Index(t => t.FourthCharacterFour_CharacterId)
                .Index(t => t.FourthEightWinner_CharacterId)
                .Index(t => t.SecondCharacterEight_CharacterId)
                .Index(t => t.SecondCharacterFinal_CharacterId)
                .Index(t => t.SecondCharacterFour_CharacterId)
                .Index(t => t.SecondEightWinner_CharacterId)
                .Index(t => t.SecondFourWinner_CharacterId)
                .Index(t => t.SeventhCharacterEight_CharacterId)
                .Index(t => t.SixthCharacterEight_CharacterId)
                .Index(t => t.ThirdCharacterEight_CharacterId)
                .Index(t => t.ThirdCharacterFour_CharacterId)
                .Index(t => t.ThirdEightWinner_CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bracket", "ThirdEightWinner_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "ThirdCharacterFour_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "ThirdCharacterEight_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "SixthCharacterEight_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "SeventhCharacterEight_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "SecondFourWinner_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "SecondEightWinner_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "SecondCharacterFour_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "SecondCharacterFinal_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "SecondCharacterEight_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "FourthEightWinner_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "FourthCharacterFour_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "FourthCharacterEight_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "FirstFourWinner_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "FirstEightWinner_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "FirstCharacterFour_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "FirstCharacterFinal_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "FirstCharacterEight_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "FinalWinner_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "FifthCharacterEight_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Bracket", "EighthCharacterEight_CharacterId", "dbo.Character");
            DropIndex("dbo.Bracket", new[] { "ThirdEightWinner_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "ThirdCharacterFour_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "ThirdCharacterEight_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "SixthCharacterEight_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "SeventhCharacterEight_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "SecondFourWinner_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "SecondEightWinner_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "SecondCharacterFour_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "SecondCharacterFinal_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "SecondCharacterEight_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "FourthEightWinner_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "FourthCharacterFour_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "FourthCharacterEight_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "FirstFourWinner_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "FirstEightWinner_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "FirstCharacterFour_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "FirstCharacterFinal_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "FirstCharacterEight_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "FinalWinner_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "FifthCharacterEight_CharacterId" });
            DropIndex("dbo.Bracket", new[] { "EighthCharacterEight_CharacterId" });
            DropTable("dbo.Bracket");
        }
    }
}
