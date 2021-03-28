using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestProject.BusinessLogic.Services;
using TestProject.BusinessLogic.Services.Interfaces;
using TestProject.DataAccess;
using TestProject.DataAccess.Repositories;
using TestProject.DataAccess.Repositories.Interfaces;

namespace TestProject.BusinessLogic.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void DependencyInjectionConnectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TestProjectContext>(options => options.UseSqlServer(connectionString));
        }

        public static void DependencyInjectionServicesConfig(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeTaskRepository, EmployeeTaskRepository>();
            services.AddTransient<IEmployeeTaskService, EmployeeTaskService>();
            services.AddScoped<DbContext, TestProjectContext>();
        }
    }
}
