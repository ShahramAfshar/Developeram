namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ShortLink", c => c.String());
            AddColumn("dbo.Articles", "MetaKeywords", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "MetaDescription", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "MetaAuthor", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "MetaOwner", c => c.String(nullable: false));
            AddColumn("dbo.Groups", "ShortLink", c => c.String());
            AddColumn("dbo.Groups", "MetaKeywords", c => c.String(nullable: false));
            AddColumn("dbo.Groups", "MetaDescription", c => c.String(nullable: false));
            AddColumn("dbo.Groups", "MetaAuthor", c => c.String(nullable: false));
            AddColumn("dbo.Groups", "MetaOwner", c => c.String(nullable: false));
            DropColumn("dbo.Articles", "Keywords");
            DropColumn("dbo.Articles", "Description");
            DropColumn("dbo.Articles", "author");
            DropColumn("dbo.Groups", "Keywords");
            DropColumn("dbo.Groups", "Description");
            DropColumn("dbo.Groups", "author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "author", c => c.String(nullable: false));
            AddColumn("dbo.Groups", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Groups", "Keywords", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "author", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "Keywords", c => c.String(nullable: false));
            DropColumn("dbo.Groups", "MetaOwner");
            DropColumn("dbo.Groups", "MetaAuthor");
            DropColumn("dbo.Groups", "MetaDescription");
            DropColumn("dbo.Groups", "MetaKeywords");
            DropColumn("dbo.Groups", "ShortLink");
            DropColumn("dbo.Articles", "MetaOwner");
            DropColumn("dbo.Articles", "MetaAuthor");
            DropColumn("dbo.Articles", "MetaDescription");
            DropColumn("dbo.Articles", "MetaKeywords");
            DropColumn("dbo.Articles", "ShortLink");
        }
    }
}
