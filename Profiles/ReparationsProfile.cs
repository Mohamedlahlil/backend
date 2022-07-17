using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class ReparationsProfile : Profile
    {
        public ReparationsProfile()
        {
            //Source-->Target
            CreateMap<Reparation, ReparationReadDto>();
            CreateMap<ReparationCreateDto, Reparation>();
            CreateMap<ReparationUpdateDto, Reparation>();
            CreateMap<Reparation, ReparationUpdateDto>();
        }
    }
}