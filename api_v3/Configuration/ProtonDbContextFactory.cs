using api_v3.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace api_v3.Configuration
{
    public class ProtonDbContextFactory : IDesignTimeDbContextFactory<ProtonDbContext>
    {
        public ProtonDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetValue<string>("ConnectionStrings:ProtonConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ProtonDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ProtonDbContext(optionsBuilder.Options);
        }

    }

}
