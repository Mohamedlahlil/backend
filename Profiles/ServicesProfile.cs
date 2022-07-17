using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            //Source-->Target
            CreateMap<Service, ServiceReadDto>();
            CreateMap<ServiceCreateDto, Service>();
            CreateMap<ServiceUpdateDto, Service>();
            CreateMap<Service, ServiceUpdateDto>();
        }
    }
}