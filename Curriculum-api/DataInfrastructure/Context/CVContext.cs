
using cv.Domain.Entity;
using DataInfrastructure.Maps;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataInfrastructure.Context
{
	public class CVContext : DbContext
	{
		public CVContext(DbContextOptions<CVContext> options)
			: base(options)
		{
		}

		public virtual DbSet<User> User { get; set; }
		public virtual DbSet<Curriculum> Curriculum { get; set; }
		public virtual DbSet<Conquistas> Conquistas { get; set; }
		public virtual DbSet<FormacaoAcademica> FormacaoAcademica { get; set; }
		public virtual DbSet<Competencias> Competencias { get; set; }
		public virtual DbSet<ExperienciaProfissional> ExperienciaProfissional { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(BaseMap<BaseEntity>)));
		}
	}
}
