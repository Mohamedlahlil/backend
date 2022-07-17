using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class CentresProfile : Profile
    {
        public CentresProfile()
        {
            //Source-->Target
            CreateMap<Centre, CentreReadDto>();
            CreateMap<CentreCreateDto, Centre>();
            CreateMap<CentreUpdateDto, Centre>();
            CreateMap<Centre, CentreUpdateDto>();
        }
    }
}