namespace BloodBank.Management.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "DonationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "DonationId");
        }
    }
}
