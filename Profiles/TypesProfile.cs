using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class TypesProfile : Profile
    {
        public TypesProfile()
        {
            //Source-->Target
            CreateMap<Type, TypeReadDto>();
            CreateMap<TypeCreateDto, Type>();
            CreateMap<TypeUpdateDto, Type>();
            CreateMap<Type, TypeUpdateDto>();
        }
    }
}