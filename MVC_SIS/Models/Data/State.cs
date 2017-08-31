using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Exercises.Attributes;

namespace Exercises.Models.Data
{
    public class State
    {
		[Required(ErrorMessage="State Abbreviation is Required")]
		[StringLength(2, MinimumLength = 2, ErrorMessage = "State Abbreviation must be 2 characters")]
		[ValidStateAbbreviation]
		[Display(Name = "State")]
		public string StateAbbreviation { get; set; }

		[Required(ErrorMessage ="State Name must be entered.")]
		[Display(Name = "State Name")]
		public string StateName { get; set; }
    }
}