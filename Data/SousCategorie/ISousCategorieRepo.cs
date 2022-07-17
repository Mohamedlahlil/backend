using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface ISousCategorieRepo
    {
        bool SaveChanges();
        IEnumerable<SousCategorie> GetAllSousCategories();
        SousCategorie GetSousCategorieById(int id);
        void CreateSousCategorie(SousCategorie scat);
        void UpdateSousCategorie(SousCategorie scat);
        void DeleteSousCategorie(SousCategorie scat);
    }
}