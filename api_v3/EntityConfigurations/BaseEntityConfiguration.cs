using api_v3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_v3.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureBaseFields(builder);
            ConfigureEntity(builder);
        }

        protected virtual void ConfigureBaseFields(EntityTypeBuilder<T> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .HasIndex(x => x.Id);
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
}
