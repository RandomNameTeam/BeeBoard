using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration) 
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IUserDbContext>(provider =>
                provider.GetService<UserDbContext>());
            services.AddDbContext<WorkerDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IWorkerDbContext>(provider =>
                provider.GetService<WorkerDbContext>());



            return services;
        }
    }
}
