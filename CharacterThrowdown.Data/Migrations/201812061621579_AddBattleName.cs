namespace CharacterThrowdown.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBattleName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Battle", "BattleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Battle", "BattleName");
        }
    }
}
