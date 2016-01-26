namespace OrderStacker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderLeg", "Order_OrderId", "dbo.Order");
            DropIndex("dbo.OrderLeg", new[] { "Order_OrderId" });
            AddColumn("dbo.OrderLeg", "OrderHeader_OrderHeaderId", c => c.Int());
            CreateIndex("dbo.OrderLeg", "OrderHeader_OrderHeaderId");
            AddForeignKey("dbo.OrderLeg", "OrderHeader_OrderHeaderId", "dbo.OrderHeader", "OrderHeaderId");
            DropColumn("dbo.OrderLeg", "Order_OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderLeg", "Order_OrderId", c => c.Int());
            DropForeignKey("dbo.OrderLeg", "OrderHeader_OrderHeaderId", "dbo.OrderHeader");
            DropIndex("dbo.OrderLeg", new[] { "OrderHeader_OrderHeaderId" });
            DropColumn("dbo.OrderLeg", "OrderHeader_OrderHeaderId");
            CreateIndex("dbo.OrderLeg", "Order_OrderId");
            AddForeignKey("dbo.OrderLeg", "Order_OrderId", "dbo.Order", "OrderId");
        }
    }
}
