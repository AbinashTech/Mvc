
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeighingAutomation.LCS.DAL;
using WeighingAutomation.LCS.DAL.Entities;
using WeighingAutomation.LCS.Repositories.Implementations;
using WeighingAutomation.LCS.Repositories.Interfaces;
using WeighingAutomation.LCS.Services.Implementations;
using WeighingAutomation.LCS.Services.Interfaces;

namespace WeighingAutomation.LCS.Services
{
    public class ConfigureDependencies
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //database
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<DbContext, AppDbContext>();

            //repositories
            services.AddScoped<IRepository<User>, Repository<User>>();

            services.AddScoped<IUserRepository, UserRepository>();

            //services
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
