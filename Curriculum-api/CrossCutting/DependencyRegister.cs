
using cv.Domain.Contracts;
using cv.Domain.Contracts.Repository;
using cv.Domain.Contracts.Services;
using DataInfrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Services;
using System;

namespace CrossCutting
{
	public static class DependencyRegister
	{
		public static void Register(this IServiceCollection services)
		{
			//repos
			services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
            //services
            services.AddScoped<IDomainValidationProvider, DomainValidationProvider>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurriculumService, CurriculumService>();
            services.AddScoped<ICurriculumRepository, CurriculumRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


        }
    }
}
