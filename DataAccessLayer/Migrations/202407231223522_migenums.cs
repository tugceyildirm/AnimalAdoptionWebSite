namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migenums : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "AnimalBreed", c => c.Int(nullable: false));
            AlterColumn("dbo.Animals", "AnimalSex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "AnimalSex", c => c.String(maxLength: 10));
            AlterColumn("dbo.Animals", "AnimalBreed", c => c.String(maxLength: 100));
        }
    }
}
