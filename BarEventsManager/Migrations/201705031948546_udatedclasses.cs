namespace BarEventsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udatedclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeCreated = c.DateTime(nullable: false),
                        Fulfilled = c.Boolean(nullable: false),
                        CustomerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatePurchased = c.DateTime(nullable: false),
                        EventsId = c.Int(nullable: false),
                        CustomerId = c.String(maxLength: 128),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventsId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.EventsId)
                .Index(t => t.CustomerId)
                .Index(t => t.Order_Id);
            
            AddColumn("dbo.Events", "EventDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Events", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Tickets", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "EventsId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "Order_Id" });
            DropIndex("dbo.Tickets", new[] { "CustomerId" });
            DropIndex("dbo.Tickets", new[] { "EventsId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            AlterColumn("dbo.Events", "EndTime", c => c.String());
            AlterColumn("dbo.Events", "StartTime", c => c.String());
            DropColumn("dbo.Events", "Price");
            DropColumn("dbo.Events", "EventDate");
            DropTable("dbo.Tickets");
            DropTable("dbo.Orders");
        }
    }
}
