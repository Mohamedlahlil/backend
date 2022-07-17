using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class AffArticleRepo : IAffArticleRepo
    {
        private readonly GPIContext __context;

        public AffArticleRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateAffArticle(AffArticle affArticle)
        {
            if (affArticle == null)
            {
                throw new ArgumentNullException(nameof(affArticle));
            }

            __context.AffArticles.Add(affArticle);
        }



        public void DeleteAffArticle(AffArticle affArticle)
        {
            if (affArticle == null)
            {
                throw new ArgumentNullException(nameof(affArticle));
            }
            __context.AffArticles.Remove(affArticle);
        }



        public IEnumerable<AffArticle> GetAllAffArticles()
        {
            return __context.AffArticles
                        .Include(c => c.Service)
                        .Include(c => c.User)
                        .ToList();
        }

        public AffArticle GetAffArticleById(int id)
        {
            return __context.AffArticles.FirstOrDefault(p => p.IdAffArticle == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateAffArticle(AffArticle affArticle)
        {
            //Nothing
        }

       
    }
}