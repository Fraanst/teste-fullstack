using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace cv.Domain.Contracts
{
	public interface IDomainValidationProvider
	{
		bool HasNotifications();
		void AddValidationError(DomainValidation validation);
		void AddValidationError(IEnumerable<DomainValidation> validations);
		void AddValidationError(string message, [CallerMemberName]string method = "");
		void AddValidationError(Exception ex, string field);
		IEnumerable<DomainValidation> Notify();
		void Clear();
	}
}
