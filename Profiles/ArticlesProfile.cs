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
            CreateMap<ArticleCreateDto, Article>();
            CreateMap<ArticleUpdateDto, Article>();
            CreateMap<Article, ArticleUpdateDto>();
        }
    }
}