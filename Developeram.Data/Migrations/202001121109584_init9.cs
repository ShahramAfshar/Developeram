namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "TitleUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "TitleUrl", c => c.String());
        }
    }
}
