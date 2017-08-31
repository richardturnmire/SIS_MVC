using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
	public class ValidStateAbbreviationAttribute : ValidationAttribute
	{

		private static string[] states = new string[]
		{
				"al", "ak", "az", "ar", "ca", "co", "ct", "de",
				"dc", "fl", "ga", "hi", "id", "il", "in", "ia",
				"ks", "ky", "la", "me", "md", "ma", "mi", "mn",
				"ms", "mo", "mt", "ne", "nv", "nh", "nj", "nm",
				"ny", "nc", "nd", "oh", "ok", "or", "pa", "pr",
				"ri", "sc", "sd", "tn", "tx", "ut", "vt", "va",
				"wa", "wv", "wi", "wy"
		};

		public override bool IsValid(object value)
		{
			if ( value is String )
			{
				var tempStr = (string)value;
				if ( states.Contains(tempStr.ToLower()) )
				{
					return true;
				}
			}
			ErrorMessage = "Invalid State Abbreviation";
			return false;
		}

	}
}