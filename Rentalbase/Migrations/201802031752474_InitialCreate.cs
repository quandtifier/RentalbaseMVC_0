namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(nullable: false),
                        DateIssued = c.DateTime(nullable: false),
                        DatePaid = c.DateTime(nullable: false),
                        Description = c.String(),
                        Cost = c.Single(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Property", t => t.PropertyID, cascadeDelete: true)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.InvoiceType",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Invoice_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Type)
                .ForeignKey("dbo.Invoice", t => t.Invoice_ID)
                .Index(t => t.Invoice_ID);
            
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
                        Type = c.String(),
                        MyLandlord_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Landord", t => t.MyLandlord_ID)
                .Index(t => t.MyLandlord_ID);
            
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
                "dbo.Landord",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PropertyType",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Property_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Type)
                .ForeignKey("dbo.Property", t => t.Property_ID)
                .Index(t => t.Property_ID);
            
            CreateTable(
                "dbo.TenantLease",
                c => new
                    {
                        TenantID = c.Int(nullable: false),
                        LeaseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TenantID, t.LeaseID })
                .ForeignKey("dbo.Lease", t => t.TenantID, cascadeDelete: true)
                .ForeignKey("dbo.Tenant", t => t.LeaseID, cascadeDelete: true)
                .Index(t => t.TenantID)
                .Index(t => t.LeaseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyType", "Property_ID", "dbo.Property");
            DropForeignKey("dbo.Property", "MyLandlord_ID", "dbo.Landord");
            DropForeignKey("dbo.TenantLease", "LeaseID", "dbo.Tenant");
            DropForeignKey("dbo.TenantLease", "TenantID", "dbo.Lease");
            DropForeignKey("dbo.Tenant", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Lease", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Invoice", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.InvoiceType", "Invoice_ID", "dbo.Invoice");
            DropIndex("dbo.TenantLease", new[] { "LeaseID" });
            DropIndex("dbo.TenantLease", new[] { "TenantID" });
            DropIndex("dbo.PropertyType", new[] { "Property_ID" });
            DropIndex("dbo.Tenant", new[] { "PropertyID" });
            DropIndex("dbo.Lease", new[] { "PropertyID" });
            DropIndex("dbo.Property", new[] { "MyLandlord_ID" });
            DropIndex("dbo.InvoiceType", new[] { "Invoice_ID" });
            DropIndex("dbo.Invoice", new[] { "PropertyID" });
            DropTable("dbo.TenantLease");
            DropTable("dbo.PropertyType");
            DropTable("dbo.Landord");
            DropTable("dbo.Tenant");
            DropTable("dbo.Lease");
            DropTable("dbo.Property");
            DropTable("dbo.InvoiceType");
            DropTable("dbo.Invoice");
        }
    }
}
