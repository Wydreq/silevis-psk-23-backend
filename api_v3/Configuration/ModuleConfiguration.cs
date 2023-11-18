using api_v3.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using api_v3.Services.Mapper;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace api_v3.Configuration
{
    public static class ModuleConfiguration
    {
        public static IConfiguration Configuration { get; set; }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuration = configuration;

            var connectionString = configuration.GetValue<string>("ConnectionStrings:ProtonConnection");

            services.AddDbContext<ProtonDbContext>(options => options.UseSqlServer(connectionString));

            services.AddSingleton(x => x.GetRequiredService<IMapperFactory>().CreateDefault());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModuleConfiguration).Assembly));

            services.AddTransient<IMapperFactory, MapperFactory>();

            services.AddCustomCors("CorsPolicy", GetParams<AppSettings>(services, configuration, "AppSettings"));

            services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            });

            return services;
        }

        private static TOptions GetParams<TOptions>(IServiceCollection services, IConfiguration configuration, string sectionName) where TOptions : class
        {
            var section = configuration.GetSection(sectionName);
            services.Configure<TOptions>(section);
            return section.Get<TOptions>();

        }
    }
}
