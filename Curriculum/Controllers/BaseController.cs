using cv.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Curriculum.Api.Controllers
{
	public class BaseController : ControllerBase
	{
		private readonly IDomainValidationProvider notification;
		public HttpResponseMessage ResponseMessage;
		public BaseController(IDomainValidationProvider _notification)
		{
			notification = _notification;
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		public IActionResult CreateResponse(object result)
		{
			IActionResult ResponseMessage;

			if (notification.HasNotifications())
				ResponseMessage = BadRequest(new { errors = notification.Notify() });
			else
				ResponseMessage = Ok(result);

			return ResponseMessage;
		}
	}
}
