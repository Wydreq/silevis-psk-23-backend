using api_v3.Entities.dict;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_v3.EntityConfigurations.dict
{
    public class StudentEntityConfiguration : BaseEntityConfiguration<StudentEntity>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.ToTable("Students", "dict");
            builder.HasIndex(x => x.StudentId).IsUnique();
        }
    }
}
