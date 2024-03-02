namespace BloodBank.Management.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDonotmodel4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donors", "BloodGroup", c => c.String());
            AddColumn("dbo.Donors", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donors", "Discriminator");
            DropColumn("dbo.Donors", "BloodGroup");
        }
    }
}
