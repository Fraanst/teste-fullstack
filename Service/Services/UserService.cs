using cv.Domain.Contracts;
using cv.Domain.Contracts.Repository;
using cv.Domain.Contracts.Services;
using cv.Domain.Entity;
using cv.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
	public class UserService : ApplicationServiceBase, IUserService
	{
		IUserRepository repos;
		public UserService(IUnitOfWork _uow,
		IDomainValidationProvider _notification,
		IUserRepository _repos) : base(_uow, _notification)
		{
			repos = _repos;
		}

		#region [ GET ]
		public int GetId()
		{
			try
			{
				var id = repos.GetId();
				if (id == 0)
				{
					AddValidationError("Não foi encontrado nenhum registro.", "GetId.UserService");
					return 0;
				}
				return id;
			}
			catch (Exception e)
			{
				AddValidationError(e);
				return 0;
			}
		}
		public List<User> GetAll()
		{
			try
			{
				var user = repos.GetAll();
				if (user == null)
				{
					AddValidationError("Não foi encontrado nenhum registro.", "GetAll.UserService");
					return null;
				}
				return user;
			}
			catch (Exception e)
			{
				AddValidationError(e);
				return null;
			}
		}

		public User GetById(int id)
		{
			try
			{
				if (id == 0)
				{
					AddValidationError("Necessário informar usuario.", "GetById.UserService");
					return null;
				}
				var user = repos.GetById(id);
				if (user == null)
				{
					AddValidationError("Não foi encontrado nenhum registro.", "GetById.UserService");
					return null;
				}
				return user;
			}
			catch (Exception e)
			{
				AddValidationError(e);
				return null;
			}
		}
		#endregion

		#region [ POST ]
		public bool Create(CreateUser dto)
		{
			try
			{
				if (string.IsNullOrEmpty(dto.Name) && string.IsNullOrEmpty(dto.Email))
				{
					AddValidationError("Necessário informar todos os campos.", "Create.UserService");
					return false;
				}
				repos.Create(dto);
				return true;
			}
			catch (Exception e)
			{
				AddValidationError(e);
				return false;
			}
		}
		#endregion

		#region [ PUT ]
		public bool Update(CreateUser dto)
		{
			try
			{
				if (dto.id == 0 && string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.Email))
				{
					AddValidationError("Necessário informar campos para alteração.", "Update.UserService");
					return false;
				}
				repos.Update(dto);
				return true;
			}
			catch (Exception e)
			{
				AddValidationError(e);
				return false;
			}
		}
		#endregion

		#region [ DELETE ]
		public bool delete(int id)
		{
			try
			{
				if (id == 0)
				{
					AddValidationError("Necessário informar usuario.", "delete.UserService");
					return false;
				}
				var user = repos.GetById(id);
				if (user == null)
				{
					AddValidationError("usuario não encontrado", "delete.UserService");
					return false;
				}
				repos.delete(id);
				return true;
			}
			catch (Exception e)
			{
				AddValidationError(e);
				return false;
			}
		}
		#endregion
	}
}
