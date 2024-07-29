namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_shop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PetShops", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PetShops", "RowVersion");
        }
    }
}
