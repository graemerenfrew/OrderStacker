namespace OrderStacker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntityIDStatusType : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderStatus", "EntityId");
            DropColumn("dbo.OrderType", "EntityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderType", "EntityId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderStatus", "EntityId", c => c.Int(nullable: false));
        }
    }
}
