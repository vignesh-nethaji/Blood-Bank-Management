namespace BloodBank.Management.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonorId = c.Int(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        DonationDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodGroupId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(nullable: false),
                        LastDonationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonorId = c.Int(nullable: false),
                        BloodGroupId = c.Int(nullable: false),
                        DonationId = c.Int(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodGroupId = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tests");
            DropTable("dbo.Recipients");
            DropTable("dbo.Inventories");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Donors");
            DropTable("dbo.Donations");
            DropTable("dbo.BloodGroups");
        }
    }
}
