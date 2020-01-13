namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Article_ArticleId", "dbo.Articles");
            DropIndex("dbo.Tags", new[] { "Article_ArticleId" });
            DropColumn("dbo.Tags", "Article_ArticleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Article_ArticleId", c => c.Int());
            CreateIndex("dbo.Tags", "Article_ArticleId");
            AddForeignKey("dbo.Tags", "Article_ArticleId", "dbo.Articles", "ArticleId");
        }
    }
}
