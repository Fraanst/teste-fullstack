using cv.Domain.Contracts.Repository;
using cv.Domain.Entity;
using cv.Domain.ViewModels;
using DataInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataInfrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly CVContext _context;

		#region Ctor
		public UserRepository(CVContext Context)
		{
			_context = Context;
		}

		#endregion

		#region [ GET ]
		public List<User> GetAll()
		{
			var user = _context.User.Where(x => x.IsDeleted == false);
			return user.OrderByDescending(u => u.CreatedAt).AsNoTracking()
				.Select(u => new User
				{
                    CurriculumId = u.CurriculumId,
                    Id = u.Id,
					Email = u.Email,
					Name = u.Name,
					CreatedAt = u.CreatedAt,
				}).ToList();
		}
		public User GetById(int id)
		{
			var user = _context.User.Where(u => u.IsDeleted == false && u.Id == id);
			return user.AsNoTracking()
				.Select(u => new User
				{
                    CurriculumId = u.CurriculumId,
                    Id = u.Id,
                    Email = u.Email,
					Name = u.Name,
					CreatedAt = u.CreatedAt,
				}).FirstOrDefault();
		}
		#endregion

		#region [ POST ]
		public bool Create(CreateUser dto)
		{
			try
			{
				var user = new User
				{
					Email = dto.Email,
					Name = dto.Name,
				};
				_context.User.Add(user);
				_context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion

		#region [ PUT ]
		public bool Update(CreateUser dto)
		{
			try
			{
				var user = _context.User.FirstOrDefault(u => u.Id == dto.id);
				if (!string.IsNullOrEmpty(dto.Email))
					user.Email = dto.Email;
				if (!string.IsNullOrEmpty(dto.Name))
					user.Name = dto.Name;
				user.UpdatedAt = DateTime.UtcNow;
				_context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion
		#region [ DELETE ]
		public bool delete(int id)
		{
			try
			{
				var user = _context.User.FirstOrDefault(u => u.Id == id);
				user.IsDeleted = true;
				user.UpdatedAt = DateTime.UtcNow;
				_context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion
	}
}
