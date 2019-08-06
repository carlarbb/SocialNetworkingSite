namespace Facebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Profiles");
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropColumn("dbo.Messages", "SenderId");
            RenameColumn(table: "dbo.Messages", name: "Sender_Id", newName: "SenderId");
            AlterColumn("dbo.Messages", "SenderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "SenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "SenderId");
            AddForeignKey("dbo.Messages", "SenderId", "dbo.Profiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Profiles");
            DropIndex("dbo.Messages", new[] { "SenderId" });
            AlterColumn("dbo.Messages", "SenderId", c => c.Int());
            AlterColumn("dbo.Messages", "SenderId", c => c.String());
            RenameColumn(table: "dbo.Messages", name: "SenderId", newName: "Sender_Id");
            AddColumn("dbo.Messages", "SenderId", c => c.String());
            CreateIndex("dbo.Messages", "Sender_Id");
            AddForeignKey("dbo.Messages", "Sender_Id", "dbo.Profiles", "Id");
        }
    }
}
