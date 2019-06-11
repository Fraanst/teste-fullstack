using cv.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Service.Services
{
	public class NotificationServiceBase
	{
		private readonly IDomainValidationProvider notification;

		public NotificationServiceBase(IDomainValidationProvider _notification)
		{
			notification = _notification;
		}

		public void AddValidationError(Exception e, [CallerMemberName]string method = "")
		{
			notification.AddValidationError(e, method);
		}

		public void AddValidationError(string message, [CallerMemberName]string method = "")
		{
			notification.AddValidationError(message, method);
		}
	}
}
