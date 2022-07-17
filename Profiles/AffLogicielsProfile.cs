using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class AffLogicielsProfile : Profile
    {
        public AffLogicielsProfile()
        {
            //Source-->Target
            CreateMap<AffLogiciel, AffLogicielReadDto>();
            CreateMap<AffLogicielCreateDto, AffLogiciel>();
            CreateMap<AffLogicielUpdateDto, AffLogiciel>();
            CreateMap<AffLogiciel, AffLogicielUpdateDto>();
        }
    }
}