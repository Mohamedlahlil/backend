using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface IAffArticleRepo
    {
        bool SaveChanges();
        IEnumerable<AffArticle> GetAllAffArticles();
        AffArticle GetAffArticleById(int id);
        void CreateAffArticle(AffArticle affArticle);
        void UpdateAffArticle(AffArticle affArticle);
        void DeleteAffArticle(AffArticle affArticle);
    }
}