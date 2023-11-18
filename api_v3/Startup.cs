using api_v3.Context;
using api_v3.Services.Mapper;
using Microsoft.EntityFrameworkCore;

namespace api_v3
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProtonDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProtonConnection")));
            services.AddControllers();

            services.AddTransient<IMapperFactory, MapperFactory>();

            //services.addMediaR()
        }

        /*
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            //using Microsoft.EntityFrameworkCore;
            //using silevis_psk_23_backend.Context;
            //using silevis_psk_23_backend.Models;

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //builder.Services.AddDbContext<TodoContext>(opt =>
            //    opt.UseInMemoryDatabase("TodoList"));

            //builder.Services.AddDbContext<ProtonContext>(opt =>
            //    opt.)

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var appl = builder.Build();

            // Configure the HTTP request pipeline.
            if (appl.Environment.IsDevelopment())
            {
                appl.UseSwagger();
                appl.UseSwaggerUI();
            }

            appl.UseAuthorization();

            appl.MapControllers();

            appl.Run();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            //app.UseStaticFiles();
            //app.UseRouting();
            //app.UseAuthorization();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}

            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.

            //builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //var application = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (application.Environment.IsDevelopment())
            //{
            //    application.UseSwagger();
            //    application.UseSwaggerUI();
            //}

            //application.UseAuthorization();

            //application.MapControllers();

            //application.Run();
        }
        */
    }
}
