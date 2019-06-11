using cv.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataInfrastructure.Maps
{
	public abstract class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(e => e.Id);

			builder
				.Property(e => e.CreatedAt)
				.UsePropertyAccessMode(PropertyAccessMode.Property);

			builder.Property(e => e.UpdatedAt)
				.ValueGeneratedOnAddOrUpdate();
		}

	}

	public class FormacaoAcademicaMap : BaseMap<FormacaoAcademica>
	{
		public override void Configure(EntityTypeBuilder<FormacaoAcademica> builder)
		{
			base.Configure(builder);
		}
	}

	public class ConquistasMap : BaseMap<Conquistas>
	{
		public override void Configure(EntityTypeBuilder<Conquistas> builder)
		{
			base.Configure(builder);
		}
	}

	public class CompetenciasMap : BaseMap<Competencias>
	{
		public override void Configure(EntityTypeBuilder<Competencias> builder)
		{
			base.Configure(builder);
		}
	}

	public class ExperienciaProfissionalMap : BaseMap<ExperienciaProfissional>
	{
		public override void Configure(EntityTypeBuilder<ExperienciaProfissional> builder)
		{
			base.Configure(builder);
		}
	}
}
