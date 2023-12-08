namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBadCustomerToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BadCostumer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BadCostumer");
        }
    }
}
