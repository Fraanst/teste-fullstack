using System;
using System.Collections.Generic;
using System.Text;

namespace cv.Domain
{
	public class DomainValidation
	{
		public string Field { get; }
		public string Message { get; }
		public DomainValidation(string message, string field)
		{
			Message = message;
			Field = field;
		}
	}
}
