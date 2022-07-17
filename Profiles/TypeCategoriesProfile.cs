using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class TypeCategoriesProfile : Profile
    {
        public TypeCategoriesProfile()
        {
            //Source-->Target
            CreateMap<TypeCategorie, TypeCategorieReadDto>();
            CreateMap<TypeCategorieCreateDto, TypeCategorie>();
            CreateMap<TypeCategorieUpdateDto, TypeCategorie>();
            CreateMap<TypeCategorie, TypeCategorieUpdateDto>();
        }
    }
}