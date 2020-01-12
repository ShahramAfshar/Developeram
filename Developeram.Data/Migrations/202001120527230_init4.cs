namespace Developeram.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "TitleUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "TitleUrl");
        }
    }
}
