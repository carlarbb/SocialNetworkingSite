namespace Facebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoandComment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Photo_Id", "dbo.Photos");
            DropForeignKey("dbo.Comments", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Comments", new[] { "Profile_Id" });
            DropIndex("dbo.Comments", new[] { "Photo_Id" });
            RenameColumn(table: "dbo.Comments", name: "Photo_Id", newName: "PhotoId");
            RenameColumn(table: "dbo.Comments", name: "Profile_Id", newName: "ProfileId");
            AddColumn("dbo.Photos", "Likes", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "FirstNameUser", c => c.String());
            AddColumn("dbo.Comments", "LastNameUser", c => c.String());
            AddColumn("dbo.Comments", "AcceptedStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Profiles", "Photo_Id", c => c.Int());
            AlterColumn("dbo.Comments", "ProfileId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "PhotoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PhotoId");
            CreateIndex("dbo.Comments", "ProfileId");
            CreateIndex("dbo.Profiles", "Photo_Id");
            AddForeignKey("dbo.Profiles", "Photo_Id", "dbo.Photos", "Id");
            AddForeignKey("dbo.Comments", "PhotoId", "dbo.Photos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "ProfileId", "dbo.Profiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Comments", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Profiles", "Photo_Id", "dbo.Photos");
            DropIndex("dbo.Profiles", new[] { "Photo_Id" });
            DropIndex("dbo.Comments", new[] { "ProfileId" });
            DropIndex("dbo.Comments", new[] { "PhotoId" });
            AlterColumn("dbo.Comments", "PhotoId", c => c.Int());
            AlterColumn("dbo.Comments", "ProfileId", c => c.Int());
            DropColumn("dbo.Profiles", "Photo_Id");
            DropColumn("dbo.Comments", "AcceptedStatus");
            DropColumn("dbo.Comments", "LastNameUser");
            DropColumn("dbo.Comments", "FirstNameUser");
            DropColumn("dbo.Photos", "Likes");
            RenameColumn(table: "dbo.Comments", name: "ProfileId", newName: "Profile_Id");
            RenameColumn(table: "dbo.Comments", name: "PhotoId", newName: "Photo_Id");
            CreateIndex("dbo.Comments", "Photo_Id");
            CreateIndex("dbo.Comments", "Profile_Id");
            AddForeignKey("dbo.Comments", "Profile_Id", "dbo.Profiles", "Id");
            AddForeignKey("dbo.Comments", "Photo_Id", "dbo.Photos", "Id");
        }
    }
}
