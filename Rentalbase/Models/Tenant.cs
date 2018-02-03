using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class Tenant
    {
        public int ID { get; set; }
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual Property MyProperty { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
    }
}