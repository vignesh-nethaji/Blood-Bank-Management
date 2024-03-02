namespace BloodBank.Management.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDonotmodel5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Donors", "BloodGroup");
            DropColumn("dbo.Donors", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Donors", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Donors", "BloodGroup", c => c.String());
        }
    }
}
