using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class SousCategoriesProfile : Profile
    {
        public SousCategoriesProfile()
        {
            //Source-->Target
            CreateMap<SousCategorie, SousCategorieReadDto>();
            CreateMap<SousCategorieCreateDto, SousCategorie>();
            CreateMap<SousCategorieUpdateDto, SousCategorie>();
            CreateMap<SousCategorie, SousCategorieUpdateDto>();
        }
    }
}