using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface ICategorieRepo
    {
        bool SaveChanges();
        IEnumerable<Categorie> GetAllCategories();
        Categorie GetCategorieById(int id);
        void CreateCategorie(Categorie cat);
        void UpdateCategorie(Categorie cat);
        void DeleteCategorie(Categorie cat);
    }
}