using cv.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace cv.Domain.ViewModels
{
	public class CreateCurriculum
	{
		public int id { get; set; }
		public int idUser { get; set; }
		public string Resumo { get; set; }
		public string End { get; set; }
		public string Telefone { get; set; }
		public string Interesses { get; set; }
		public string Linkedin { get; set; }
		public string SITE { get; set; }
		public int UserId { get; set; }
		public List<Conquistas> Conquistas { get; set; }
		public List<FormacaoAcademica> FormacaoAcademica { get; set; }
		public List<Competencias> Competencias { get; set; }
		public List<ExperienciaProfissional> ExperienciaProfissional { get; set; }
	}
}
