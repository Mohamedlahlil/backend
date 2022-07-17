using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class ReparationRepo : IReparationRepo
    {
        private readonly GPIContext __context;

        public ReparationRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateReparation(Reparation reparation)
        {
            if (reparation == null)
            {
                throw new ArgumentNullException(nameof(reparation));
            }

            __context.Reparations.Add(reparation);
        }



        public void DeleteReparation(Reparation reparation)
        {
            if (reparation == null)
            {
                throw new ArgumentNullException(nameof(reparation));
            }
            __context.Reparations.Remove(reparation);
        }



        public IEnumerable<Reparation> GetAllReparations()
        {
            return __context.Reparations
                        .Include(c => c.Article)
                        .Include(c => c.Fournisseur)
                        .ToList();
        }

        public Reparation GetReparationById(int id)
        {
            return __context.Reparations.FirstOrDefault(p => p.IdReparation == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateReparation(Reparation reparation)
        {
            //Nothing
        }




    }
}