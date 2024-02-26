namespace BloodBank.Management.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedHospital : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hospitals", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Hospitals", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Hospitals", "Mobile", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hospitals", "Mobile", c => c.String());
            AlterColumn("dbo.Hospitals", "Location", c => c.String());
            AlterColumn("dbo.Hospitals", "Name", c => c.String());
        }
    }
}
