namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequestTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "AnimalID", "dbo.Animals");
            DropIndex("dbo.Requests", new[] { "AnimalID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Requests", "AnimalID");
            AddForeignKey("dbo.Requests", "AnimalID", "dbo.Animals", "AnimalID", cascadeDelete: true);
        }
    }
}
