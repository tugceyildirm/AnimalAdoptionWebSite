namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PetShops", "RowVersion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PetShops", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
