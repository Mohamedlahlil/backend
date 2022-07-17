using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class AffArticlesProfile : Profile
    {
        public AffArticlesProfile()
        {
            //Source-->Target
            CreateMap<AffArticle, AffArticleReadDto>();
            CreateMap<AffArticleCreateDto, AffArticle>();
            CreateMap<AffArticleUpdateDto, AffArticle>();
            CreateMap<AffArticle, AffArticleUpdateDto>();
        }
    }
}