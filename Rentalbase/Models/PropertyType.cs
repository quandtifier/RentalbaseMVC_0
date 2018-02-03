using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class PropertyType
    {
        [Key]
        public string Type { get; set; }
        public string Description { get; set; }
    }
}