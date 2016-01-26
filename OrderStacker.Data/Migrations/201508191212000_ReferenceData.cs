namespace OrderStacker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReferenceData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Code = c.String(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderStatusId);
            
            CreateTable(
                "dbo.OrderType",
                c => new
                    {
                        OrderTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Code = c.String(),
                        EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderTypeId);
            
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
            
            DropTable("dbo.Trade");
        }
        
        public override void Down()
        {
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
            
            DropTable("dbo.Trade");
            DropTable("dbo.OrderType");
            DropTable("dbo.OrderStatus");
        }
    }
}
