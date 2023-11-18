using api_v3.Configuration;
using AutoMapper;

namespace api_v3.Services.Mapper
{
    public class MapperFactory : IMapperFactory
    {
        public IMapper CreateDefault() =>
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            })
            .CreateMapper();

        public IMapper CreateWithDefault(Profile profile) =>
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                cfg.AddProfile(profile);
            })
            .CreateMapper();

    }
}
