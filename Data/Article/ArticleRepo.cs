using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class ArticleRepo : IArticleRepo
    {
        private readonly GPIContext __context;

        public ArticleRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            __context.Articles.Add(article);
        }



        public void DeleteArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            __context.Articles.Remove(article);
        }



        public IEnumerable<Article> GetAllArticles()
        {
            return __context.Articles
                        .Include(c => c.AffArticle)
                        .Include(c => c.Fournisseur)
                        .Include(c => c.Type)
                        .ToList();
        }

        public Article GetArticleById(int id)
        {
            return __context.Articles.FirstOrDefault(p => p.IdArticle == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateArticle(Article article)
        {
            //Nothing
        }




    }
}