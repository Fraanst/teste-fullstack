
using cv.Domain.ConfigurationService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Curriculum.Api.Startups
{
	public static class ConfigurationStartup
	{
		public static void ConfigurationRegister(this IServiceCollection services, IConfiguration Configuration)
		{
			ConectionStrings config = new ConectionStrings();
			new ConfigureFromConfigurationOptions<ConectionStrings>(Configuration.GetSection("ConnectionStrings")).Configure(config);
			services.AddSingleton(config);

		}
	}
}
