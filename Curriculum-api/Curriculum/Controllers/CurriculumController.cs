using cv.Domain.Contracts;
using cv.Domain.Contracts.Services;
using cv.Domain.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Curriculum.Api.Controllers
{
	[Route("Curriculum")]
	[ApiController]
	public class CurriculumController : BaseController
	{
		ICurriculumService service;
		public CurriculumController(IDomainValidationProvider _notification, ICurriculumService _service) : base(_notification)
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
		public IActionResult Create([FromBody]CreateCurriculum dto)
		{
			return CreateResponse(service.Create(dto));
		}

		[HttpPut("Update")]
		public IActionResult Update([FromBody]CreateCurriculum dto)
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
