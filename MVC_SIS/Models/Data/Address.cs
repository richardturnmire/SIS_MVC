using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Address
    {
		[Required(ErrorMessage="AddressId field is missing.  It is required")]
        public int AddressId { get; set; }

		[Display(Name = "Street Address 1")]
		[Required(ErrorMessage ="Address 1 is required")]
        public string Street1 { get; set; }

		[Display(Name = "Street Address 2")]
		public string Street2 { get; set; }

		[Display(Name = "City")]
		[Required(ErrorMessage ="City is required")]
        public string City { get; set; }

		[Display(Name = "State")]
		public State State { get; set; }

		[Required]
		[Display(Name = "Zip Code")]
		[DataType(DataType.PostalCode)]
		[RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage ="Invalid Zip Code")]
        public string PostalCode { get; set; }
    }
}