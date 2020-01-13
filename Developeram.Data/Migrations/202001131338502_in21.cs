namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class in21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MetaTags", "Article_ArticleId", "dbo.Articles");
            DropForeignKey("dbo.MetaTags", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.MetaTags", new[] { "Article_ArticleId" });
            DropIndex("dbo.MetaTags", new[] { "Group_GroupId" });
            AddColumn("dbo.Articles", "Keywords", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "author", c => c.String(nullable: false));
            AddColumn("dbo.Groups", "Keywords", c => c.String(nullable: false));
            AddColumn("dbo.Groups", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Groups", "author", c => c.String(nullable: false));
            DropTable("dbo.MetaTags");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.MetaTagId);
            
            DropColumn("dbo.Groups", "author");
            DropColumn("dbo.Groups", "Description");
            DropColumn("dbo.Groups", "Keywords");
            DropColumn("dbo.Articles", "author");
            DropColumn("dbo.Articles", "Description");
            DropColumn("dbo.Articles", "Keywords");
            CreateIndex("dbo.MetaTags", "Group_GroupId");
            CreateIndex("dbo.MetaTags", "Article_ArticleId");
            AddForeignKey("dbo.MetaTags", "Group_GroupId", "dbo.Groups", "GroupId");
            AddForeignKey("dbo.MetaTags", "Article_ArticleId", "dbo.Articles", "ArticleId");
        }
    }
}
