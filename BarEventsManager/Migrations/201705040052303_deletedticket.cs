namespace BarEventsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedticket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "EventsId", "dbo.Events");
            DropForeignKey("dbo.Tickets", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Tickets", new[] { "EventsId" });
            DropIndex("dbo.Tickets", new[] { "CustomerId" });
            DropIndex("dbo.Tickets", new[] { "Order_Id" });
            CreateTable(
                "dbo.OrderEvents",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Events_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Events_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Events_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Events_Id);
            
            DropTable("dbo.Tickets");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.OrderEvents", "Events_Id", "dbo.Events");
            DropForeignKey("dbo.OrderEvents", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderEvents", new[] { "Events_Id" });
            DropIndex("dbo.OrderEvents", new[] { "Order_Id" });
            DropTable("dbo.OrderEvents");
            CreateIndex("dbo.Tickets", "Order_Id");
            CreateIndex("dbo.Tickets", "CustomerId");
            CreateIndex("dbo.Tickets", "EventsId");
            AddForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Tickets", "CustomerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "EventsId", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
