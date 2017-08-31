using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Major
    {
		[Required(ErrorMessage="MajorId field is missing.  It is required. Contact IT")]
        public int MajorId { get; set; }

		[Required(ErrorMessage ="Major Name is required.")]
		[Display(Name = "Major")]
		public string MajorName { get; set; }
    }
}