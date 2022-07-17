using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class RoleusersProfile : Profile
    {
        public RoleusersProfile()
        {
            //Source-->Target
            CreateMap<Roleuser, RoleuserReadDto>();
            CreateMap<RoleuserCreateDto, Roleuser>();
            CreateMap<RoleuserUpdateDto, Roleuser>();
            CreateMap<Roleuser, RoleuserUpdateDto>();
        }
    }
}