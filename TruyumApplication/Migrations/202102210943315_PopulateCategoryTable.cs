namespace TruyumApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Category values('Main Course')");
            Sql("insert into Category values('Starters')");
            Sql("insert into Category values('Snack')");
            Sql("insert into Category values('Dessert')");
        }
        
        public override void Down()
        {
        }
    }
}
