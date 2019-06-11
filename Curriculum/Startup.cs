
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataInfrastructure.Context;
using CrossCutting;
using Swashbuckle.AspNetCore.Swagger;
using Curriculum.Api.Startups;

namespace Curriculum
{
	public class Startup
	{

		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }
		public void ConfigureServices(IServiceCollection services)
		{

			services.ConfigurationRegister(Configuration);
			services.Register();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "curriculum", Version = "v1" });
			});

			services.AddDbContext<CVContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConnString")));


			services.AddCors();
		}

		//This method gets called by the runtime.Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseCors(builder =>
			builder
			.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod());

			app.UseSwagger();

			if (env.IsDevelopment())
			{
				//app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("../swagger/v1/swagger.json", "Sentinela");
			});

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
