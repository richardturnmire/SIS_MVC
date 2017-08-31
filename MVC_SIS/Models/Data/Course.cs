using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Course
    {
		[Required(ErrorMessage="CourseId field is missing.  It is required.  Contact IT")]
		public int CourseId { get; set; }
		[Required(ErrorMessage ="Course Name is required")]
		[Display(Name = "Course Title")]
		public string CourseName { get; set; }
    }
}