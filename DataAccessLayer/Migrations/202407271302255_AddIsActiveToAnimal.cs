namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveToAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "IsActive");
        }
    }
}
