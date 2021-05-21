using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class MgrRegisration
    {
		[Required]
		public int CustomerID { get; set; }     // foreign key property
		public Customer Customer { get; set; }  // navigation property

		[Required]
		public int ProductID { get; set; }     // foreign key property
		public Product Product { get; set; }   // navigation property

		public List<Product> Products { get; set; }
	}
}
