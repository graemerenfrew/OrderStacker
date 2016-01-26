namespace OrderStacker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreatedModifiedDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Account", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trade", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trade", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderHeader", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderHeader", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderLeg", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderLeg", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Order", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Order", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderStatus", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderStatus", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderType", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderType", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "DateCreated");
            DropColumn("dbo.User", "DateModified");
            DropColumn("dbo.OrderType", "DateCreated");
            DropColumn("dbo.OrderType", "DateModified");
            DropColumn("dbo.OrderStatus", "DateCreated");
            DropColumn("dbo.OrderStatus", "DateModified");
            DropColumn("dbo.Order", "DateCreated");
            DropColumn("dbo.Order", "DateModified");
            DropColumn("dbo.OrderLeg", "DateCreated");
            DropColumn("dbo.OrderLeg", "DateModified");
            DropColumn("dbo.OrderHeader", "DateCreated");
            DropColumn("dbo.OrderHeader", "DateModified");
            DropColumn("dbo.Trade", "DateCreated");
            DropColumn("dbo.Trade", "DateModified");
            DropColumn("dbo.Account", "DateCreated");
            DropColumn("dbo.Account", "DateModified");
        }
    }
}
