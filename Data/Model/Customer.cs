using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Data.Model
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string  Name { get; set; }

    }
}
