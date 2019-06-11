using cv.Domain.Contracts;
using cv.Domain.Contracts.Repository;
using cv.Domain.Contracts.Services;
using cv.Domain.Entity;
using cv.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
	public class CurriculumService : ApplicationServiceBase, ICurriculumService
	{
		ICurriculumRepository repos;
		public CurriculumService(IUnitOfWork _uow,
		IDomainValidationProvider _notification,
		ICurriculumRepository _repos) : base(_uow, _notification)
		{
			repos = _repos;
		}

		#region [ GET ]
		public List<Curriculum> GetAll()
		{
			try
			{
				var user = repos.GetAll();
				if (user == null)
				{
					AddValidationError("Não foi encontrado nenhum registro.", "GetAll.CurriculumService");
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

		public Curriculum GetById(int id)
		{
			try
			{
				if (id == 0)
				{
					AddValidationError("Necessário informar currículo.", "GetById.CurriculumService");
					return null;
				}
				var user = repos.GetById(id);
				if (user == null)
				{
					AddValidationError("Não foi encontrado nenhum registro.", "GetById.CurriculumService");
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
		public bool Create(CreateCurriculum dto)
		{
			try
			{
                if (dto.idUser == 0)
                {
                    AddValidationError("Necessário associar um usuário.", "Create.CurriculumService");
                    return false;
                }
                var cv = repos.GetAll().FirstOrDefault(x => x.UserId == dto.idUser);
                if (cv != null)
                {
                    AddValidationError("Já existe um contrato para esse usuário.", "Create.CurriculumService");
                    return false;
                }
                if (string.IsNullOrEmpty(dto.Telefone) && string.IsNullOrEmpty(dto.End))
				{
					AddValidationError("Necessário informar os campos de Endereço e Telefone.", "Create.CurriculumService");
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
		public bool Update(CreateCurriculum dto)
		{
			try
			{
				if (dto == null)
				{
					AddValidationError("Necessário informar campos para alteração.", "Update.CurriculumService");
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
					AddValidationError("Necessário informar currículo.", "delete.CurriculumService");
					return false;
				}
				var cv = repos.GetById(id);
				if (cv == null)
				{
					AddValidationError("currículo não encontrado", "delete.CurriculumService");
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
