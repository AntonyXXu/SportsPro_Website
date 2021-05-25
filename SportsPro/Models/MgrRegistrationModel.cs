﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class MgrRegistrationModel
    {
		public ICollection<CustomerProduct> CustomerProducts { get; set; }

        public int CustomerID { get; set; }
        public int ProductID { get; set; }

        public Customer Customer { get; set; }
        
    }
}