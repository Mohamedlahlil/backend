using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class VillesProfile : Profile
    {
        public VillesProfile()
        {
            //Source-->Target
            CreateMap<Ville, VilleReadDto>();
            CreateMap<VilleCreateDto, Ville>();
            CreateMap<VilleUpdateDto, Ville>();
            CreateMap<Ville, VilleUpdateDto>();
        }
    }
}