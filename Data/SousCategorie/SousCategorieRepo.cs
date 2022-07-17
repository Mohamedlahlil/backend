using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class SousCategorieRepo : ISousCategorieRepo
    {
        private readonly GPIContext __context;

        public SousCategorieRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateSousCategorie(SousCategorie sousCategorie)
        {
            if (sousCategorie == null)
            {
                throw new ArgumentNullException(nameof(sousCategorie));
            }

            __context.SousCategories.Add(sousCategorie);
        }



        public void DeleteSousCategorie(SousCategorie sousCategorie)
        {
            if (sousCategorie == null)
            {
                throw new ArgumentNullException(nameof(sousCategorie));
            }
            __context.SousCategories.Remove(sousCategorie);
        }



        public IEnumerable<SousCategorie> GetAllSousCategories()
        {
            return __context.SousCategories
                        .Include(c => c.TypeCategorie)
                        .Include(c => c.Categorie)
                        .ToList();
            //  return __context.SousCategories.Include(c => c.Categorie).ToList();
        }

        public SousCategorie GetSousCategorieById(int id)
        {
            return __context.SousCategories.FirstOrDefault(p => p.IdSousCat == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateSousCategorie(SousCategorie sousCategorie)
        {
            //Nothing
        }

        
    }
}