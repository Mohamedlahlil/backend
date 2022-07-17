using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;

namespace GPI.Data
{
    public class TypeCategorieRepo : ITypeCategorieRepo
    {
        private readonly GPIContext __context;

        public TypeCategorieRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateTypeCategorie(TypeCategorie tcat)
        {
            if (tcat == null)
            {
                throw new ArgumentNullException(nameof(tcat));
            }

            __context.TypeCategories.Add(tcat);
        }



        public void DeleteTypeCategorie(TypeCategorie cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException(nameof(cat));
            }
            __context.TypeCategories.Remove(cat);
        }



        public IEnumerable<TypeCategorie> GetAllTypeCategories()
        {
            return __context.TypeCategories.ToList();
        }

        public TypeCategorie GetTypeCategorieById(int id)
        {
            return __context.TypeCategories.FirstOrDefault(p => p.IdTypeCategorie == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateTypeCategorie(TypeCategorie cat)
        {
            //Nothing
        }




    }
}