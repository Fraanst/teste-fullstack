using cv.Domain.Entity;
using cv.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace cv.Domain.Contracts.Services
{
	public interface ICurriculumService
	{
		List<Curriculum> GetAll();
		Curriculum GetById(int id);
		bool Create(CreateCurriculum dto);
		bool Update(CreateCurriculum dto);
		bool delete(int id);
	}
}
