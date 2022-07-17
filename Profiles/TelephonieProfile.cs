using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class TelephoniesProfile : Profile
    {
        public TelephoniesProfile()
        {
            //Source-->Target
            CreateMap<Telephonie, TelephonieReadDto>();
            CreateMap<TelephonieCreateDto, Telephonie>();
            CreateMap<TelephonieUpdateDto, Telephonie>();
            CreateMap<Telephonie, TelephonieUpdateDto>();
        }
    }
}