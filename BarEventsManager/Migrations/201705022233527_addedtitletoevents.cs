namespace BarEventsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtitletoevents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Title");
        }
    }
}
