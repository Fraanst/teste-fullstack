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
	public class CurriculumRepository : ICurriculumRepository
	{
		private readonly CVContext _context;

		#region Ctor
		public CurriculumRepository(CVContext Context)
		{
			_context = Context;
		}
		#endregion

		#region [ GET ]
		public List<Curriculum> GetAll()
		{
			var cv = _context.Curriculum.Where(x => x.IsDeleted == false);
			return cv.OrderByDescending(u => u.CreatedAt).AsNoTracking()
				.Select(u => new Curriculum
				{
					End = u.End,
					Interesses = u.Interesses,
					Resumo = u.Resumo,
					Telefone = u.Telefone,
					Linkedin = u.Linkedin,
					SITE = u.SITE,
					User = u.User,
					UserId = u.UserId,
                    Competencias = u.Competencias,
					ExperienciaProfissional = u.ExperienciaProfissional,
					Conquistas = u.Conquistas,
					FormacaoAcademica = u.FormacaoAcademica,
					CreatedAt = u.CreatedAt,
				}).ToList();
		}
		public Curriculum GetById(int id)
		{
			var cv = _context.Curriculum.Where(x => x.IsDeleted == false && x.Id == id);
			return cv.AsNoTracking()
			.Select(u => new Curriculum
			{
                Id = u.Id,
				End = u.End,
				Interesses = u.Interesses,
				Resumo = u.Resumo,
				Telefone = u.Telefone,
				Linkedin = u.Linkedin,
                UserId = u.UserId,
                SITE = u.SITE,
				User = u.User,
				Competencias = u.Competencias,
				ExperienciaProfissional = u.ExperienciaProfissional,
				Conquistas = u.Conquistas,
				FormacaoAcademica = u.FormacaoAcademica,
				CreatedAt = u.CreatedAt,
			}).FirstOrDefault();
		}
		#endregion

		#region [ POST ]
		public bool Create(CreateCurriculum dto)
		{
			var Cv = new Curriculum
			{
				UserId = dto.idUser,
				End = dto.End,
				Interesses = dto.Interesses,
				Linkedin = dto.Linkedin,
				Resumo = dto.Resumo,
				SITE = dto.SITE,
				Telefone = dto.Telefone,
				Competencias = dto.Competencias,
				Conquistas = dto.Conquistas,
				ExperienciaProfissional = dto.ExperienciaProfissional,
				FormacaoAcademica = dto.FormacaoAcademica
			};
			_context.Curriculum.Add(Cv);
			_context.SaveChanges();
            var user = _context.User.FirstOrDefault(x => x.Id == Cv.UserId);
            user.CurriculumId = Cv.Id;
            _context.SaveChanges();
            return true;
		}
		#endregion

		#region [ PUT ]
		public bool Update(CreateCurriculum dto)
		{
			var Cv = _context.Curriculum.FirstOrDefault(u => u.Id == dto.id);
			if (!string.IsNullOrEmpty(dto.End))
				Cv.End = dto.End;
			if (!string.IsNullOrEmpty(dto.Interesses))
				Cv.Interesses = dto.Interesses;
			if(!string.IsNullOrEmpty(dto.Linkedin))
				Cv.Linkedin = dto.Linkedin;
			if (!string.IsNullOrEmpty(dto.Resumo))
				Cv.Resumo = dto.Resumo;
			if (!string.IsNullOrEmpty(dto.SITE))
				Cv.SITE = dto.SITE;
			if (!string.IsNullOrEmpty(dto.Telefone))
				Cv.Telefone = dto.Telefone;
			_context.SaveChanges();
			return true;
		}
		#endregion
		#region [ DELETE ]
		public bool delete(int id)
		{
			var user = _context.Curriculum.FirstOrDefault(u => u.Id == id);
			user.IsDeleted = true;
			_context.SaveChanges();
			return true;
		}
		#endregion

	}
}
