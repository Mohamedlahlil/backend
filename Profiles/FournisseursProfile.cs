using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class FournisseursProfile : Profile
    {
        public FournisseursProfile()
        {
            //Source-->Target
            CreateMap<Fournisseur, FournisseurReadDto>();
            CreateMap<FournisseurCreateDto, Fournisseur>();
            CreateMap<FournisseurUpdateDto, Fournisseur>();
            CreateMap<Fournisseur, FournisseurUpdateDto>();
        }
    }
}