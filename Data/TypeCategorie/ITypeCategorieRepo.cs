using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface ITypeCategorieRepo
    {
        bool SaveChanges();
        IEnumerable<TypeCategorie> GetAllTypeCategories();
        TypeCategorie GetTypeCategorieById(int id);
        void CreateTypeCategorie(TypeCategorie tcat);
        void UpdateTypeCategorie(TypeCategorie tcat);
        void DeleteTypeCategorie(TypeCategorie tcat);
    }
}