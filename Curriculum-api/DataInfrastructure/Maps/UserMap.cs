using cv.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataInfrastructure.Maps
{
	public class UserMap : BaseMap<User>
	{
		public override void Configure(EntityTypeBuilder<User> builder)
		{
			base.Configure(builder);

            builder.HasOne<Curriculum>(x => x.Curriculum).WithOne(x => x.User).HasForeignKey<Curriculum>(x => x.UserId);
		}
	}
}
