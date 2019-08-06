namespace Facebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentType");
        }
    }
}
