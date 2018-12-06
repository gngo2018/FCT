namespace CharacterThrowdown.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        FirstItemId = c.Int(nullable: false),
                        SecondItemId = c.Int(nullable: false),
                        WinnerCharacterId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        Location = c.String(nullable: false),
                        FirstCharacter_CharacterId = c.Int(),
                        FirstItem_ItemId = c.Int(),
                        SecondCharacter_CharacterId = c.Int(),
                        SecondItem_ItemId = c.Int(),
                        WinnerCharacter_CharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.BattleId)
                .ForeignKey("dbo.Character", t => t.FirstCharacter_CharacterId)
                .ForeignKey("dbo.Item", t => t.FirstItem_ItemId)
                .ForeignKey("dbo.Character", t => t.SecondCharacter_CharacterId)
                .ForeignKey("dbo.Item", t => t.SecondItem_ItemId)
                .ForeignKey("dbo.Character", t => t.WinnerCharacter_CharacterId)
                .Index(t => t.FirstCharacter_CharacterId)
                .Index(t => t.FirstItem_ItemId)
                .Index(t => t.SecondCharacter_CharacterId)
                .Index(t => t.SecondItem_ItemId)
                .Index(t => t.WinnerCharacter_CharacterId);
            
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CharacterName = c.String(nullable: false),
                        CharacterUniverse = c.Int(nullable: false),
                        CharacterAbility = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ItemName = c.String(),
                        ItemDescription = c.String(),
                        ItemType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Battle", "WinnerCharacter_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Battle", "SecondItem_ItemId", "dbo.Item");
            DropForeignKey("dbo.Battle", "SecondCharacter_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Battle", "FirstItem_ItemId", "dbo.Item");
            DropForeignKey("dbo.Battle", "FirstCharacter_CharacterId", "dbo.Character");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Battle", new[] { "WinnerCharacter_CharacterId" });
            DropIndex("dbo.Battle", new[] { "SecondItem_ItemId" });
            DropIndex("dbo.Battle", new[] { "SecondCharacter_CharacterId" });
            DropIndex("dbo.Battle", new[] { "FirstItem_ItemId" });
            DropIndex("dbo.Battle", new[] { "FirstCharacter_CharacterId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Item");
            DropTable("dbo.Character");
            DropTable("dbo.Battle");
        }
    }
}
