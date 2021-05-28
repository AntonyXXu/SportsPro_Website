using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Technician
    {
		public int TechnicianID { get; set; }

		[Required(ErrorMessage = "Please enter a technician name.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter an email address.")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter a phone number.")]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"^([0-9]+(-[0-9]+)+)$", ErrorMessage = "Invalid Phone Number.  Please use XXX-XXX-XXXX")]
		public string Phone { get; set; }
	}
}
