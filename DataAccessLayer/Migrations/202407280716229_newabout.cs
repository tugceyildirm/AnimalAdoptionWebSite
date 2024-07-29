namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newabout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutDetails3", c => c.String(maxLength: 1000));
            AddColumn("dbo.Abouts", "AboutDetails4", c => c.String(maxLength: 1000));
            DropColumn("dbo.Abouts", "AboutImg1");
            DropColumn("dbo.Abouts", "AboutImg2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "AboutImg2", c => c.String(maxLength: 100));
            AddColumn("dbo.Abouts", "AboutImg1", c => c.String(maxLength: 100));
            DropColumn("dbo.Abouts", "AboutDetails4");
            DropColumn("dbo.Abouts", "AboutDetails3");
        }
    }
}
