﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public int PropertyID { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DatePaid { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        [ForeignKey("InvoiceType")]
        public string Type { get; set; }

        public virtual Property MyProperty { get; set; }
    }
}