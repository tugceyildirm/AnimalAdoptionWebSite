namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRowVersionToAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "RowVersion");
        }
    }
}
