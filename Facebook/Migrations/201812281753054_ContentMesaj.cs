namespace Facebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentMesaj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Content");
        }
    }
}
