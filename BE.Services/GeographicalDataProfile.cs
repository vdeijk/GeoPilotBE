using AutoMapper;
using BE.Data.DTOs;
using BE.Data.Entities;

namespace BE.Services
{
    public class GeographicalDataProfile : Profile
    {
        public GeographicalDataProfile()
        {
            CreateMap<GeographicalDataEntity, GeographicalDataDto>();
            CreateMap<CreateGeographicalDataDto, GeographicalDataEntity>();
            CreateMap<UpdateGeographicalDataDto, GeographicalDataEntity>();
        }
    }
}
