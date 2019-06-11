using cv.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataInfrastructure.Maps
{
    public class CurriculumMap : BaseMap<Curriculum>
	{
		public override void Configure(EntityTypeBuilder<Curriculum> builder)
		{
			base.Configure(builder);

            builder.HasOne<User>(x => x.User).WithOne(x => x.Curriculum);
        }
    }
}
