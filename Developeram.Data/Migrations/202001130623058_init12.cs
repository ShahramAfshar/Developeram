namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Tags", new[] { "ArticleId" });
            RenameColumn(table: "dbo.Tags", name: "ArticleId", newName: "Article_ArticleId");
            AddColumn("dbo.Tags", "GroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "Article_ArticleId", c => c.Int());
            CreateIndex("dbo.Tags", "GroupId");
            CreateIndex("dbo.Tags", "Article_ArticleId");
            AddForeignKey("dbo.Tags", "GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "Article_ArticleId", "dbo.Articles", "ArticleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Article_ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Tags", "GroupId", "dbo.Groups");
            DropIndex("dbo.Tags", new[] { "Article_ArticleId" });
            DropIndex("dbo.Tags", new[] { "GroupId" });
            AlterColumn("dbo.Tags", "Article_ArticleId", c => c.Int(nullable: false));
            DropColumn("dbo.Tags", "GroupId");
            RenameColumn(table: "dbo.Tags", name: "Article_ArticleId", newName: "ArticleId");
            CreateIndex("dbo.Tags", "ArticleId");
            AddForeignKey("dbo.Tags", "ArticleId", "dbo.Articles", "ArticleId", cascadeDelete: true);
        }
    }
}
