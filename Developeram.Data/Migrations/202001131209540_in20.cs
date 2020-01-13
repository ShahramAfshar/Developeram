namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class in20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MetaTags",
                c => new
                    {
                        MetaTagId = c.Int(nullable: false, identity: true),
                        Keywords = c.String(nullable: false),
                        Article_ArticleId = c.Int(),
                        Group_GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.MetaTagId)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId)
                .Index(t => t.Article_ArticleId)
                .Index(t => t.Group_GroupId);
            
            DropColumn("dbo.Articles", "MetaDescription");
            DropColumn("dbo.Articles", "MetaOwner");
            DropColumn("dbo.Articles", "MetaKeywords");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "MetaKeywords", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "MetaOwner", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "MetaDescription", c => c.String(nullable: false));
            DropForeignKey("dbo.MetaTags", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.MetaTags", "Article_ArticleId", "dbo.Articles");
            DropIndex("dbo.MetaTags", new[] { "Group_GroupId" });
            DropIndex("dbo.MetaTags", new[] { "Article_ArticleId" });
            DropTable("dbo.MetaTags");
        }
    }
}
