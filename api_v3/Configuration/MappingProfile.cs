using api_v3.Entities.dict;
using api_v3.Models;
using AutoMapper;

namespace api_v3.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //MapApp();
            MapDict();
            //MapDbo();
            //MapCommands();
            //MapViewModels();
        }

        private void MapDict()
        {
            CreateMap<StudentEntity, StudentDto>();
        }
    }
}
