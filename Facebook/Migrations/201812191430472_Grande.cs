namespace Facebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Grande : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Profiles", new[] { "Profile_Id" });
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ReceiverId, cascadeDelete: true)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.ProfileProfiles",
                c => new
                    {
                        Profile_Id = c.Int(nullable: false),
                        Profile_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_Id, t.Profile_Id1 })
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id1)
                .Index(t => t.Profile_Id)
                .Index(t => t.Profile_Id1);
            
            AddColumn("dbo.Profiles", "Notification_Id", c => c.Int());
            AlterColumn("dbo.Profiles", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Profiles", "UserId");
            CreateIndex("dbo.Profiles", "Notification_Id");
            AddForeignKey("dbo.Profiles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Profiles", "Notification_Id", "dbo.Notifications", "Id");
            DropColumn("dbo.Profiles", "Profile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Profile_Id", c => c.Int());
            DropForeignKey("dbo.Notifications", "ReceiverId", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "Notification_Id", "dbo.Notifications");
            DropForeignKey("dbo.Profiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProfileProfiles", "Profile_Id1", "dbo.Profiles");
            DropForeignKey("dbo.ProfileProfiles", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.ProfileProfiles", new[] { "Profile_Id1" });
            DropIndex("dbo.ProfileProfiles", new[] { "Profile_Id" });
            DropIndex("dbo.Notifications", new[] { "ReceiverId" });
            DropIndex("dbo.Profiles", new[] { "Notification_Id" });
            DropIndex("dbo.Profiles", new[] { "UserId" });
            AlterColumn("dbo.Profiles", "UserId", c => c.String());
            DropColumn("dbo.Profiles", "Notification_Id");
            DropTable("dbo.ProfileProfiles");
            DropTable("dbo.Notifications");
            CreateIndex("dbo.Profiles", "Profile_Id");
            AddForeignKey("dbo.Profiles", "Profile_Id", "dbo.Profiles", "Id");
        }
    }
}
