using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            //Source-->Target
            CreateMap<Categorie, CategorieReadDto>();
            CreateMap<CategorieCreateDto, Categorie>();
            CreateMap<CategorieUpdateDto, Categorie>();
            CreateMap<Categorie, CategorieUpdateDto>();
        }
    }
}