namespace BloodBank.Management.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRecipient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Recipients", "Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.Recipients", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipients", "Email", c => c.String());
            AlterColumn("dbo.Recipients", "Mobile", c => c.String());
            AlterColumn("dbo.Recipients", "Name", c => c.String());
        }
    }
}
