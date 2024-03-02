namespace BloodBank.Management.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDonotmodel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Donors", "Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.Donors", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "Address", c => c.String());
            AlterColumn("dbo.Donors", "Mobile", c => c.String());
            AlterColumn("dbo.Donors", "Name", c => c.String());
        }
    }
}
