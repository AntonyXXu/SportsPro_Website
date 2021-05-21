using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class MgrRegisrationModel
    {
		
		public int CustomerID { get; set; }     // foreign key property
		public Customer Customer { get; set; }  // navigation property

		
		public int ProductID { get; set; }     // foreign key property
		public Product Name { get; set; }   // navigation property

		public List<Product> Products { get; set; }
	}
}
