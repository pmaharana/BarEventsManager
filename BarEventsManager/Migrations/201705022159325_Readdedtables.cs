namespace BarEventsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Readdedtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        GenreId = c.Int(nullable: false),
                        VenueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Events", "VenueId", "dbo.Venues");
            DropIndex("dbo.Events", new[] { "VenueId" });
            DropIndex("dbo.Events", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Venues");
            DropTable("dbo.Events");
        }
    }
}
