namespace NorthWind.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Age");
        }
    }
}
