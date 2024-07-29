namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Animals", "RowVersion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
