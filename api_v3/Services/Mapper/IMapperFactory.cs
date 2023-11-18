using AutoMapper;

namespace api_v3.Services.Mapper
{
    public interface IMapperFactory
    {
        IMapper CreateDefault();
        IMapper CreateWithDefault(Profile profile);
    }
}
