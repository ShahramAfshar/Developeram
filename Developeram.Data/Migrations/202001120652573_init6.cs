namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        WebSite = c.String(),
                        Message = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ParentID = c.Int(),
                        Comment2_CommentID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.Comment2_CommentID)
                .Index(t => t.ArticleId)
                .Index(t => t.Comment2_CommentID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactUsId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Question = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactUsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Comments", "Comment2_CommentID", "dbo.Comments");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Tags", new[] { "ArticleId" });
            DropIndex("dbo.Comments", new[] { "Comment2_CommentID" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropTable("dbo.ContactUs");
            DropTable("dbo.Tags");
            DropTable("dbo.Comments");
        }
    }
}
