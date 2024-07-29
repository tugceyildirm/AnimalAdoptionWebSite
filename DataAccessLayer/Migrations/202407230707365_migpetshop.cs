namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migpetshop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PetShops", "ProductImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PetShops", "ProductImage");
        }
    }
}
