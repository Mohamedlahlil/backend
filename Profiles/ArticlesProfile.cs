using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class ArticlesProfile : Profile
    {
        public ArticlesProfile()
        {
            //Source-->Target
            CreateMap<Article, ArticleReadDto>();
            CreateMap<ArtcleCreateDto, Article>();
            CreateMap<ArticleUpdateDto, Article>();
            CreateMap<Article, ArticleUpdateDto>();
        }
    }
}