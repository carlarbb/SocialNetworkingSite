namespace Facebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lastmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "Photo_Id", "dbo.Photos");
            DropIndex("dbo.Profiles", new[] { "Photo_Id" });
            CreateTable(
                "dbo.ProfilePhotoes",
                c => new
                    {
                        Profile_Id = c.Int(nullable: false),
                        Photo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_Id, t.Photo_Id })
                .ForeignKey("dbo.Profiles", t => t.Profile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.Photo_Id, cascadeDelete: true)
                .Index(t => t.Profile_Id)
                .Index(t => t.Photo_Id);
            
            AddColumn("dbo.Chats", "GroupId", c => c.Int());
            CreateIndex("dbo.Chats", "GroupId");
            AddForeignKey("dbo.Chats", "GroupId", "dbo.Groups", "Id");
            DropColumn("dbo.Profiles", "Photo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Photo_Id", c => c.Int());
            DropForeignKey("dbo.ProfilePhotoes", "Photo_Id", "dbo.Photos");
            DropForeignKey("dbo.ProfilePhotoes", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.Chats", "GroupId", "dbo.Groups");
            DropIndex("dbo.ProfilePhotoes", new[] { "Photo_Id" });
            DropIndex("dbo.ProfilePhotoes", new[] { "Profile_Id" });
            DropIndex("dbo.Chats", new[] { "GroupId" });
            DropColumn("dbo.Chats", "GroupId");
            DropTable("dbo.ProfilePhotoes");
            CreateIndex("dbo.Profiles", "Photo_Id");
            AddForeignKey("dbo.Profiles", "Photo_Id", "dbo.Photos", "Id");
        }
    }
}
