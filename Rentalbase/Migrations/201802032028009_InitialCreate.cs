namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lease",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        TentantID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        DurationMonths = c.Int(nullable: false),
                        RateMonthly = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Property", t => t.PropertyID, cascadeDelete: true)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LandlordID = c.Int(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Property", t => t.PropertyID, cascadeDelete: true)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.TenantLease",
                c => new
                    {
                        Tenant_ID = c.Int(nullable: false),
                        Lease_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tenant_ID, t.Lease_ID })
                .ForeignKey("dbo.Tenant", t => t.Tenant_ID, cascadeDelete: true)
                .ForeignKey("dbo.Lease", t => t.Lease_ID, cascadeDelete: true)
                .Index(t => t.Tenant_ID)
                .Index(t => t.Lease_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenant", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.TenantLease", "Lease_ID", "dbo.Lease");
            DropForeignKey("dbo.TenantLease", "Tenant_ID", "dbo.Tenant");
            DropForeignKey("dbo.Lease", "PropertyID", "dbo.Property");
            DropIndex("dbo.TenantLease", new[] { "Lease_ID" });
            DropIndex("dbo.TenantLease", new[] { "Tenant_ID" });
            DropIndex("dbo.Tenant", new[] { "PropertyID" });
            DropIndex("dbo.Lease", new[] { "PropertyID" });
            DropTable("dbo.TenantLease");
            DropTable("dbo.Tenant");
            DropTable("dbo.Property");
            DropTable("dbo.Lease");
        }
    }
}
