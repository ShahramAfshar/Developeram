namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "TitleUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "TitleUrl");
        }
    }
}
