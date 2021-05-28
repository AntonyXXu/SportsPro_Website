using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Incident
    {
		public int IncidentID { get; set; }

		[Required(ErrorMessage = "Please select a customer.")]
		public int CustomerID { get; set; }     // foreign key property
		public Customer Customer { get; set; }  // navigation property

		[Required(ErrorMessage = "Please select a product")]
		public int ProductID { get; set; }     // foreign key property
		public Product Product { get; set; }   // navigation property

		public int? TechnicianID { get; set; }     // foreign key property - nullable
		public Technician Technician { get; set; }   // navigation property

		[Required(ErrorMessage = "Please select a Title.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Please enter a description.")]
		public string Description { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/DD}")]
		public DateTime DateOpened { get; set; } = DateTime.Now;

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/DD}")]
		public DateTime? DateClosed { get; set; } = null;

	}



}
