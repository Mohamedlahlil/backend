using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class AffHistoriquesProfile : Profile
    {
        public AffHistoriquesProfile()
        {
            //Source-->Target
            CreateMap<AffHistorique, AffHistoriqueReadDto>();
            CreateMap<AffHistoriqueCreateDto, AffHistorique>();
            CreateMap<AffHistoriqueUpdateDto, AffHistorique>();
            CreateMap<AffHistorique, AffHistoriqueUpdateDto>();
        }
    }
}