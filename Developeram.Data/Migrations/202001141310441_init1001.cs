namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1001 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "MetaDescription");
            DropColumn("dbo.Groups", "MetaDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "MetaDescription", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "MetaDescription", c => c.String(nullable: false));
        }
    }
}
