using cv.Domain.Entity;
using cv.Domain.ViewModels;
using System.Collections.Generic;

namespace cv.Domain.Contracts.Repository
{
	public interface ICurriculumRepository
	{
		List<Curriculum> GetAll();
		Curriculum GetById(int id);
		bool Create(CreateCurriculum dto);
		bool Update(CreateCurriculum dto);
		bool delete(int id);

	}
}
