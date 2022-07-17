using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;

namespace GPI.Data
{
    public class SqlCategorieRepo : ICategorieRepo
    {
        private readonly GPIContext __context;

        public SqlCategorieRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateCategorie(Categorie cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException(nameof(cat));
            }

            __context.Categories.Add(cat);
        }



        public void DeleteCategorie(Categorie cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException(nameof(cat));
            }
            __context.Categories.Remove(cat);
        }



        public IEnumerable<Categorie> GetAllCategories()
        {
            return __context.Categories.ToList();
        }

        public Categorie GetCategorieById(int id)
        {
            return __context.Categories.FirstOrDefault(p => p.IdCategorie == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateCategorie(Categorie cat)
        {
            //Nothing
        }




    }
}