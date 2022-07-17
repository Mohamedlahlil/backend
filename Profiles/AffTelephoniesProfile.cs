using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class AffTelephoniesProfile : Profile
    {
        public AffTelephoniesProfile()
        {
            //Source-->Target
            CreateMap<AffTelephonie, AffTelephonieReadDto>();
            CreateMap<AffTelephonieCreateDto, AffTelephonie>();
            CreateMap<AffTelephonieUpdateDto, AffTelephonie>();
            CreateMap<AffTelephonie, AffTelephonieUpdateDto>();
        }
    }
}