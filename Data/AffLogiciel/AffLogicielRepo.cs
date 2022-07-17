using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class AffLogicielRepo : IAffLogicielRepo
    {
        private readonly GPIContext __context;

        public AffLogicielRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateAffLogiciel(AffLogiciel affLogiciel)
        {
            if (affLogiciel == null)
            {
                throw new ArgumentNullException(nameof(affLogiciel));
            }

            __context.AffLogiciels.Add(affLogiciel);
        }



        public void DeleteAffLogiciel(AffLogiciel affLogiciel)
        {
            if (affLogiciel == null)
            {
                throw new ArgumentNullException(nameof(affLogiciel));
            }
            __context.AffLogiciels.Remove(affLogiciel);
        }



        public IEnumerable<AffLogiciel> GetAllAffLogiciels()
        {
            return __context.AffLogiciels
                        .Include(c => c.User)
                        .ToList();
        }

        public AffLogiciel GetAffLogicielById(int id)
        {
            return __context.AffLogiciels.FirstOrDefault(p => p.IdAffLogiciel == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateAffLogiciel(AffLogiciel affLogiciel)
        {
            //Nothing
        }




    }
}