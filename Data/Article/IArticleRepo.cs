using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IArticleRepo
    {
        bool SaveChanges();
        IEnumerable<Article> GetAllArticles();
        Article GetArticleById(int id);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(Article article);
    }
}