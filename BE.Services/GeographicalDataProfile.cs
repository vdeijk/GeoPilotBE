using AutoMapper;
using BE.Domain.DTOs;
using BE.Domain.Entities;

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
