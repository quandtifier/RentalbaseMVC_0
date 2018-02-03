using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class Property
    {
        public int ID { get; set; }
        public int LandlordID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int Value{ get; set; }
        public string Description { get; set; }
        [ForeignKey("PropertyType")]
        public string Type { get; set; }

        public virtual Landord MyLandlord { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual ICollection<PropertyType> PropertyType { get; set; }
    }
}