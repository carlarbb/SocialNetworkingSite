namespace Facebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Country", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "Country", c => c.String());
            AlterColumn("dbo.Profiles", "City", c => c.String());
            AlterColumn("dbo.Profiles", "LastName", c => c.String());
            AlterColumn("dbo.Profiles", "FirstName", c => c.String());
        }
    }
}
