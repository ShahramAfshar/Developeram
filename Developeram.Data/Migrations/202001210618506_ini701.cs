namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini701 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagArticles",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagArticles", "ArticleId", "dbo.Articles");
            DropIndex("dbo.TagArticles", new[] { "ArticleId" });
            DropTable("dbo.TagArticles");
        }
    }
}
