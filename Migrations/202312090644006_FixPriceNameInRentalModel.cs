namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPriceNameInRentalModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Rentals", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Rentals", "Price");
        }
    }
}
