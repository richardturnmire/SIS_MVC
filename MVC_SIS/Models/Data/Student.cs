using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student
    {
		[Required(ErrorMessage="StudentId field is missing. It is required. Contact IT")]
		public int StudentId { get; set; }

		[Required(ErrorMessage ="First Name must be entered")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage ="Last Name must be entered")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required(ErrorMessage ="GPA must be entered")]
		[Range(0, 4, ErrorMessage ="GPA must be between 0 and 4.0")]
        public decimal GPA { get; set; }

        public Address Address { get; set; }
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
    }
}