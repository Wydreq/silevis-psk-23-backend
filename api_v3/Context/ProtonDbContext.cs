//using Microsoft.EntityFrameworkCore;
//using api_v3.Models;
//using api_v3.Entities;
//using api_v3.Entities.dict;

using api_v3.Entities;
using api_v3.Entities.dict;
using api_v3.Models;
using Microsoft.EntityFrameworkCore;

namespace api_v3.Context
{
    public class ProtonDbContext : DbContext
    {
        public ProtonDbContext(DbContextOptions<ProtonDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public Task<int> SaveChangesWithBaseFieldAsync(string user, CancellationToken cancellationToken = default)
        {
            var enties = ChangeTracker
                .Entries()
                .Where(x =>
                    x.Entity is IModificableEntity &&
                    (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in enties)
            {
                var entity = (IModificableEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.DtCrt = DateTime.Now;
                    entity.UsrCrt = user;
                }
                else
                {
                    entity.DtChg = DateTime.Now;
                    entity.UsrChg = user;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<api_v3.Entities.dict.StudentEntity> StudentEntity { get; set; } = default!;
        //public DbSet<api_v3.Models.StudentDto> StudentDto { get; set; } = default!;

        //public DbSet<StudentDto> Students { get; set; }
        //public DbSet<api_v3.Entities.dict.StudentEntity> StudentEntity { get; set; } = default!;

    }

}
