using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class InvoiceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Type { get; set; }
        public string Description { get; set; }
    }
}