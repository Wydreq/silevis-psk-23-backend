using api_v3.Context;
using Microsoft.EntityFrameworkCore;

namespace api_v3.Configuration
{
    public static class ModuleConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("ConnectionStrings:ProtonConnection");

            services.AddDbContext<ProtonDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
