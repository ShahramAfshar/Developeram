namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ShortText = c.String(nullable: false),
                        FullText = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MetaDescription = c.String(nullable: false),
                        MetaOwner = c.String(nullable: false),
                        MetaKeywords = c.String(nullable: false),
                        ImageName = c.String(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "GroupId", "dbo.Groups");
            DropIndex("dbo.Articles", new[] { "GroupId" });
            DropTable("dbo.Articles");
        }
    }
}
