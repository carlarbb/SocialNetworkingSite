namespace Facebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoImpact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "NrPositiveComments", c => c.Int(nullable: false));
            AddColumn("dbo.Photos", "NrNegativeComments", c => c.Int(nullable: false));
            AddColumn("dbo.Photos", "NrNeutralComments", c => c.Int(nullable: false));
            AddColumn("dbo.Photos", "PhotoImpact", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "PhotoImpact");
            DropColumn("dbo.Photos", "NrNeutralComments");
            DropColumn("dbo.Photos", "NrNegativeComments");
            DropColumn("dbo.Photos", "NrPositiveComments");
        }
    }
}
