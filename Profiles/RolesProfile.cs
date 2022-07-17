using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            //Source-->Target
            CreateMap<Role, RoleReadDto>();
            CreateMap<RoleCreateDto, Role>();
            CreateMap<RoleUpdateDto, Role>();
            CreateMap<Role, RoleUpdateDto>();
        }
    }
}