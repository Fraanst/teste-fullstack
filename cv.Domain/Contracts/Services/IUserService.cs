using cv.Domain.Entity;
using cv.Domain.ViewModels;
using System.Collections.Generic;

namespace cv.Domain.Contracts.Services
{
	public interface IUserService
	{
		List<User> GetAll();
		User GetById(int id);
		bool Create(CreateUser dto);
		bool Update(CreateUser dto);
		bool delete(int id);
	}
}
