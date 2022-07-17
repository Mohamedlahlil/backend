using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class PausessProfile : Profile
    {
        public PausessProfile()
        {
            //Source-->Target
            CreateMap<Pauses, PausesReadDto>();
            CreateMap<PausesCreateDto, Pauses>();
            CreateMap<PausesUpdateDto, Pauses>();
            CreateMap<Pauses, PausesUpdateDto>();
        }
    }
}