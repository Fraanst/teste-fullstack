using cv.Domain.Contracts;
using cv.Domain.Contracts.Services;
using cv.Domain.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curriculum.Api.Controllers
{
	[Route("User")]
	[ApiController]
	public class UserController : BaseController
	{
		IUserService service;
		public UserController(IDomainValidationProvider _notification, IUserService _service) : base(_notification)
		{
			service = _service;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			return CreateResponse(service.GetAll());
		}

		[HttpGet("GetById")]
		public IActionResult GetById([FromHeader]int id)
		{
			return CreateResponse(service.GetById(id));
		}
		[HttpPost("Create")]
		public IActionResult Create([FromBody]CreateUser dto)
		{
			return CreateResponse(service.Create(dto));
		}

		[HttpPut("Update")]
		public IActionResult Update([FromBody]CreateUser dto)
		{
			return CreateResponse(service.Update(dto));
		}

		[HttpPut("Delete")]
		public IActionResult Delete([FromHeader]int id)
		{
			return CreateResponse(service.delete(id));
		}
	}
}
