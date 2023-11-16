using Microsoft.EntityFrameworkCore;
using PhoneNumberChecker.Application.Mappers;
using PhoneNumberChecker.Application.Services;
using PhoneNumberChecker.Data.Access;
using PhoneNumberChecker.Data.Access.Repository;

namespace PhoneNumberChecker.Web.Server
{
    public static class ServiceRegistry
    {
        public static IServiceCollection ServiceRegistryContainer(this IServiceCollection services, IConfiguration config)
        {
            //services.AddScoped<NumberCheckerService>();
            //services.AddScoped(typeof(INumberCheckerRepository), typeof(NumberCheckerRepository));
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped(typeof(AutoMapper.Mapper));
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("PhoneNumberChecker"), m => m.MigrationsAssembly("PhoneNumberChecker.Data.Access"));
            });

            return services;
        }
    }
}
