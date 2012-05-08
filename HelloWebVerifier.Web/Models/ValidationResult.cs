using System;

namespace HelloWebVerifier.Web.Models
{
	public class ValidationResult
	{
		public bool Valid { get; protected set; }
		public string Reason { get; protected set; }

		public ValidationResult(bool valid, string reason)
		{
			Valid = valid;
			Reason = reason;
		}
	}
}