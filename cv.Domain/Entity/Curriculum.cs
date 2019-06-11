using System;
using System.Collections.Generic;
using System.Text;

namespace cv.Domain.Entity
{
	public class Curriculum : BaseEntity
	{
		public User User { get; set; }
		public int UserId { get; set; }
		public string Resumo { get; set; }
		public string End { get; set; }
		public string Telefone { get; set; }
		public string Interesses { get; set; }
		public string Linkedin { get; set; }
		public string SITE { get; set; }
		public List<Conquistas> Conquistas { get; set; }
		public List<FormacaoAcademica> FormacaoAcademica { get; set; }
		public List<Competencias> Competencias { get; set; }
		public List<ExperienciaProfissional> ExperienciaProfissional { get; set; }

	}
	public class Conquistas : BaseEntity
	{
		public Curriculum Curriculum { get; set; }
		public int CurriculumId { get; set; }
		public string Conquista { get; set; }
		public string Observacao { get; set; }
		public DateTime DateConquista { get; set; }
	}
	public class Competencias : BaseEntity
	{
		public Curriculum Curriculum { get; set; }
		public int CurriculumId { get; set; }
		public string Competencia { get; set; }
		public int Nivel { get; set; }
	}
	public class ExperienciaProfissional : BaseEntity
	{
		public Curriculum Curriculum { get; set; }
		public int CurriculumId { get; set; }
		public string Empresa { get; set; }
		public string Cargo { get; set; }
		public string Atribuicoes { get; set; }
		public DateTime DateIn { get; set; }
		public DateTime DateEnd { get; set; }
	}
	public class FormacaoAcademica : BaseEntity
	{
		public Curriculum Curriculum { get; set; }
		public int CurriculumId { get; set; }
		public string Instituicao { get; set; }
		public string Curso { get; set; }
		public DateTime Datein { get; set; }
		public DateTime DateEnd { get; set; }
	}
}
