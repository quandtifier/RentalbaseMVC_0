namespace Rentalbase.Migrations
{
    using Rentalbase.DAL;
    using Rentalbase.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rentalbase.DAL.RBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rentalbase.DAL.RBaseContext context)
        {
            
            var propertyTypes = new List<PropertyType>
            {
                new PropertyType {Type="STUDIO"},
                new PropertyType {Type="APARTMENT"},
                new PropertyType {Type="SFH"},
            };
            propertyTypes.ForEach(s => context.PropertyTypes.AddOrUpdate(p => p.Type, s));
            context.SaveChanges();

            var invoiceTypes = new List<InvoiceType>
            {
                new InvoiceType {Type="MAINTENANCE"},
                new InvoiceType {Type="RENT"},
                new InvoiceType {Type="DAMAGE"},
                new InvoiceType {Type="DEPOSIT"},
            };
            invoiceTypes.ForEach(s => context.InvoiceTypes.AddOrUpdate(p => p.Type, s));
            context.SaveChanges();

            var landlords = new List<Landord>
            {
                new Landord { ID=1, Name="Joshua Lansang", Street="332 Lake Forest Drive", City="Seattle", State="WA", Zip=11111, Phone="1111111111", Email="jlansang@rbase.com"},
                new Landord { ID=2, Name="Michael Quandt", Street="74 Lookout Ave.", City="Silverlake", State="WA", Zip=22222, Phone="2222222222", Email="mquandt@rbase.com"},
                new Landord { ID=3, Name="Alex Reid", Street="834 Ashley St.", City="Malone", State="WA", Zip=33333, Phone="3333333333", Email="areid@rbase.com"},
            };
            landlords.ForEach(s => context.Landlords.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var properties = new List<Property>
            {
                new Property { ID=1, LandlordID=1, Street="38 Galvin Road", City="Seattle", State="WA", Zip=98181, Value=5000, Description="Need something here", Type="SFH"},
                new Property { ID=2, LandlordID=1, Street="61 North Mulbary", City="Seattle", State="WA", Zip=98182, Value=10000, Description="Need something here", Type="STUDIO"},
                new Property { ID=3, LandlordID=1, Street="856 South Pl", City="Seattle", State="WA", Zip=98183, Value=20000, Description="Need something here", Type="APARTMENT"},
                new Property { ID=4, LandlordID=1, Street="4738 West Dr.", City="Seattle", State="WA", Zip=98184, Value=40000, Description="Need something here", Type="SFH"},

                new Property { ID=5, LandlordID=2, Street="40 Sample Dr.", City="Tacoma", State="WA", Zip=98321, Value=99000, Description="Need something here", Type="STUDIO"},
                new Property { ID=6, LandlordID=2, Street="50 Sample Dr.", City="Tacoma", State="WA", Zip=98322, Value=100000, Description="Need something here", Type="STUDIO"},
                new Property { ID=7, LandlordID=2, Street="60 Sample Dr.", City="Tacoma", State="WA", Zip=98323, Value=101000, Description="Need something here", Type="STUDIO"},
                new Property { ID=8, LandlordID=2, Street="70 Sample Dr.", City="Tacoma", State="WA", Zip=98324, Value=102000, Description="Need something here", Type="STUDIO"},

                new Property { ID=9, LandlordID=3, Street="10 Sample Dr.", City="Olympia", State="WA", Zip=98410, Value=300000, Description="Need something here", Type="APARTMENT"},
                new Property { ID=10, LandlordID=3, Street="20 Sample Dr.", City="Olympia", State="WA", Zip=98411, Value=310000, Description="Need something here", Type="APARTMENT"},
                new Property { ID=11, LandlordID=3, Street="30 Sample Dr.", City="Olympia", State="WA", Zip=98412, Value=320000, Description="Need something here", Type="APARTMENT"},
                new Property { ID=12, LandlordID=3, Street="35 Sample Dr.", City="Olympia", State="WA", Zip=98413, Value=330000, Description="Need something here", Type="APARTMENT"},
            };
            properties.ForEach(s => context.Properties.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var tenants = new List<Tenant>
            {
                new Tenant { ID=1, PropertyID=1, Name="Thomas M Anders", Phone="2063651375", Email="tanders@gmail.com", RegistrationDate=DateTime.Parse("2010-01-01")},
                new Tenant { ID=2, PropertyID=1, Name="Jen Anders", Phone="2063651375", Email="janders@gmail.com", RegistrationDate=DateTime.Parse("2010-01-01")},

                new Tenant { ID=3, PropertyID=5, Name="Jake Jakson", Phone="2830937463", Email="jj@gmail.com", RegistrationDate=DateTime.Parse("2012-02-01")},
                new Tenant { ID=4, PropertyID=2, Name="Franky Fish", Phone="2063653789", Email="ff@gmail.com", RegistrationDate=DateTime.Parse("2012-10-01")},
            };
            tenants.ForEach(s => context.Tenants.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var leases = new List<Lease>
            {
                new Lease { ID=1, PropertyID=1, TentantID=1, StartDate=DateTime.Parse("2010-01-01"), DurationMonths=12, RateMonthly=2000.00, Tenants= new List<Tenant>()},
                new Lease { ID=2, PropertyID=5, TentantID=3, StartDate=DateTime.Parse("2012-02-01"), DurationMonths=12, RateMonthly=2000.00, Tenants= new List<Tenant>()},
                new Lease { ID=3, PropertyID=2, TentantID=1, StartDate=DateTime.Parse("2010-10-01"), DurationMonths=12, RateMonthly=2000.00, Tenants= new List<Tenant>()},
            };
            leases.ForEach(s => context.Leases.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            AddOrUpdateTenant(context, 1, "Thomas M Anders");
            AddOrUpdateTenant(context, 1, "Jen Anders");
            AddOrUpdateTenant(context, 2, "Jake Jakson");
            AddOrUpdateTenant(context, 3, "Franky Fish");


            var invoices = new List<Invoice>
            {
                new Invoice { ID=1, PropertyID=1, DateIssued=DateTime.Parse("2010-01-23"), DatePaid=DateTime.Parse("2010-02-02"), Description="Rent Payment", Cost=2000.00, Type="RENT"},
                new Invoice { ID=3, PropertyID=1, DateIssued=DateTime.Parse("2010-02-23"), DatePaid=DateTime.Parse("2010-03-02"), Description="Rent Payment", Cost=2000.00, Type="RENT"},
                new Invoice { ID=4, PropertyID=1, DateIssued=DateTime.Parse("2010-03-23"), DatePaid=DateTime.Parse("2010-04-02"), Description="Rent Payment", Cost=2000.00, Type="RENT"},
                new Invoice { ID=5, PropertyID=1, DateIssued=DateTime.Parse("2010-04-23"), DatePaid=DateTime.Parse("2010-05-02"), Description="Rent Payment", Cost=2000.00, Type="RENT"},

                new Invoice { ID=6, PropertyID=2, DateIssued=DateTime.Parse("2012-02-23"), DatePaid=DateTime.Parse("2012-03-02"), Description="Rent Payment", Cost=2000.00, Type="RENT"},
                new Invoice { ID=7, PropertyID=2, DateIssued=DateTime.Parse("2012-03-23"), DatePaid=DateTime.Parse("2012-04-02"), Description="Rent Payment", Cost=2000.00, Type="RENT"},
                new Invoice { ID=8, PropertyID=2, DateIssued=DateTime.Parse("2012-04-23"), DatePaid=DateTime.Parse("2012-05-02"), Description="Rent Payment", Cost=2000.00, Type="RENT"},
                new Invoice { ID=9, PropertyID=2, DateIssued=DateTime.Parse("2012-05-23"), DatePaid=DateTime.Parse("2012-06-02"), Description="Rent Payment", Cost=2000.00, Type="RENT"},

                new Invoice { ID=10, PropertyID=3, DateIssued=DateTime.Parse("2017-05-23"), DatePaid=DateTime.Parse("2018-01-02"), Description="Rent Payment", Cost=2000.00, Type="DAMAGE"},
            };
            invoices.ForEach(s => context.Invoices.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();
        }

        void AddOrUpdateTenant(RBaseContext context, int leaseID, string tenantName)
        {
            var ls = context.Leases.SingleOrDefault(l => l.ID == leaseID);
            var ten = ls.Tenants.SingleOrDefault(t => t.Name == tenantName);
            if (ten == null)
                ls.Tenants.Add(context.Tenants.Single(t => t.Name == tenantName));
        }
    }
}
