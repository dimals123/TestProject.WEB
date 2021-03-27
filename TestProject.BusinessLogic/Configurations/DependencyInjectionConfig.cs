using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestProject.DataAccess;

namespace TestProject.BusinessLogic.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void DependencyInjectionConnectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TestProjectContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
