namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixBadCustomerColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BadCustomer", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "BadCostumer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BadCostumer", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "BadCustomer");
        }
    }
}
