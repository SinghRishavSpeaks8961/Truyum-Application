namespace TruyumApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItem", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItem", "Active");
        }
    }
}
