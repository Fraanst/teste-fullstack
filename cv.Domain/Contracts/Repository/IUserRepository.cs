using cv.Domain.Entity;
using cv.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace cv.Domain.Contracts.Repository
{
	public interface IUserRepository
	{
		List<User> GetAll();
		User GetById(int id);
		bool Create(CreateUser dto);
		bool Update(CreateUser dto);
		bool delete(int id);
		int GetId();
	}
}
