using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class Lease
    {
        public int ID { get; set; }
        public int PropertyID { get; set; }
        public int TentantID { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationMonths { get; set; }
        public float RateMonthly { get; set; }

        public virtual Property MyProperty { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}