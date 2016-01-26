namespace OrderStacker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ShortCode = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Commodity",
                c => new
                    {
                        CommodityId = c.Int(nullable: false, identity: true),
                        MarketId = c.Int(nullable: false),
                        Description = c.String(),
                        ShortCode = c.String(),
                    })
                .PrimaryKey(t => t.CommodityId);
            
            CreateTable(
                "dbo.Market",
                c => new
                    {
                        MarketId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ShortCode = c.String(),
                    })
                .PrimaryKey(t => t.MarketId);
            
            CreateTable(
                "dbo.OrderHeader",
                c => new
                    {
                        OrderHeaderId = c.Int(nullable: false, identity: true),
                        TotalQuantity = c.Int(nullable: false),
                        ValidUntilTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderHeaderId)
                .ForeignKey("dbo.Order", t => t.Order_OrderId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.OrderLeg",
                c => new
                    {
                        OrderLegId = c.Int(nullable: false, identity: true),
                        IsBuy = c.Boolean(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PromptDate = c.DateTime(nullable: false),
                        Limit = c.Single(nullable: false),
                        StopLoss = c.Single(nullable: false),
                        CurrencyISOCode = c.String(),
                        Rate = c.Single(nullable: false),
                        BaseLimit = c.Single(nullable: false),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderLegId)
                .ForeignKey("dbo.Order", t => t.Order_OrderId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        EnteredByUserId = c.Int(nullable: false),
                        CommodityId = c.Int(nullable: false),
                        OrderTypeId = c.Int(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Trade",
                c => new
                    {
                        TradeId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        OrderHeaderId = c.Int(nullable: false),
                        OrderLegId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        FXRate = c.Single(nullable: false),
                        FilledByUserId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TradeId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        LoginEmail = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLeg", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderHeader", "Order_OrderId", "dbo.Order");
            DropIndex("dbo.OrderLeg", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderHeader", new[] { "Order_OrderId" });
            DropTable("dbo.User");
            DropTable("dbo.Trade");
            DropTable("dbo.Order");
            DropTable("dbo.OrderLeg");
            DropTable("dbo.OrderHeader");
            DropTable("dbo.Market");
            DropTable("dbo.Commodity");
            DropTable("dbo.Account");
        }
    }
}
