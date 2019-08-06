namespace Facebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "Description");
        }
    }
}
