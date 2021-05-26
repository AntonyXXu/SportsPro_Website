using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SportsPro.Models
{
    public class Customer
    {
		public int CustomerID { get; set; }

		[StringLength(51, ErrorMessage = "First Name must not exceed 50 characters")]
		[Required(ErrorMessage = "Please enter a First Name")]
		public string FirstName { get; set; }

		[StringLength(51, ErrorMessage = "Last Name must not exceed 50 characters")]
		[Required(ErrorMessage = "Please enter a Last Name")]
		public string LastName { get; set; }

		[StringLength(51, ErrorMessage = "Address must not exceed 50 characters")]
		[Required(ErrorMessage = "Please enter an Address")]
		public string Address { get; set; }

		[StringLength(51, ErrorMessage = "City must not exceed 50 characters")]
		[Required(ErrorMessage = "Please enter a City")]
		public string City { get; set; }

		[StringLength(51, ErrorMessage = "State must not exceed 50 characters")]
		[Required(ErrorMessage = "Please enter a State")]
		public string State { get; set; }

		[StringLength(21, ErrorMessage = "State must not exceed 50 characters")]
		[Required(ErrorMessage = "Please enter a Postal Code")]
		public string PostalCode { get; set; }

		[Required(ErrorMessage = "Please select a Country")]
		public string CountryID { get; set; }
		public Country Country { get; set; }

		[RegularExpression("^[(]\\d{3}[)]\\s\\d{3}[-]\\d{4}$", ErrorMessage = "Please input in format (000) 000-0000")]
		public string Phone { get; set; }

		[DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
		[StringLength(51, ErrorMessage = "Address must not exceed 50 characters")]
		public string Email { get; set; }

		public string FullName => FirstName + " " + LastName;   // read-only property

		public ICollection<CustomerProduct> CustomerProducts { get; set; }
	}

}