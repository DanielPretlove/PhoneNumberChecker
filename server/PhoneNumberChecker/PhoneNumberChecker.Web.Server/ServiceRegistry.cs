using Microsoft.EntityFrameworkCore;
using PhoneNumberChecker.Application.Services;
using PhoneNumberChecker.Data.Access;
using PhoneNumberChecker.Data.Access.Repositories;

namespace PhoneNumberChecker.Web.Server
{
    public static class ServiceRegistry
    {
        public static IServiceCollection ServiceRegistryContainer(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<NumberCheckerService>();
            services.AddScoped<CountryService>();
            services.AddScoped(typeof(ICountryReposiotry), typeof(CountryRepository));
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("PhoneNumberChecker"), m => m.MigrationsAssembly("PhoneNumberChecker.Data.Access"));
            });

            return services;
        }
    }
}
