using api_v3.Configuration;
using api_v3.Context;
using api_v3.Services.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Drawing.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddDbContext<ProtonDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProtonConnection")));

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:5152",
                            "http://localhost:4200");
    });
}
);

builder.Services.AddTransient<IMapperFactory, MapperFactory>();

    //services.addMediaR()

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();


