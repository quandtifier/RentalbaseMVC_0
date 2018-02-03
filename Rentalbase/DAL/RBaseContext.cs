using Rentalbase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Rentalbase.DAL
{
    public class RBaseContext : DbContext
    {
        public RBaseContext() : base("RBaseContext")
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Landord> Landlords { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Lease>()
                .HasMany(l => l.Tenants).WithMany(t => t.Leases)
                .Map(v => v.MapLeftKey("TenantID")
                .MapRightKey("LeaseID")
                .ToTable("TenantLease"));
        }
    }
}
