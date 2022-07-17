using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class LogicielsProfile : Profile
    {
        public LogicielsProfile()
        {
            //Source-->Target
            CreateMap<Logiciel, LogicielReadDto>();
            CreateMap<LogicielCreateDto, Logiciel>();
            CreateMap<LogicielUpdateDto, Logiciel>();
            CreateMap<Logiciel, LogicielUpdateDto>();
        }
    }
}