using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class SqlCentreRepo : ICentreRepo
    {
        private readonly GPIContext __context;

        public SqlCentreRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateCentre(Centre centre)
        {
            if (centre == null)
            {
                throw new ArgumentNullException(nameof(centre));
            }

            __context.Centres.Add(centre);
        }



        public void DeleteCentre(Centre centre)
        {
            if (centre == null)
            {
                throw new ArgumentNullException(nameof(centre));
            }
            __context.Centres.Remove(centre);
        }



        public IEnumerable<Centre> GetAllCentres()
        {
            return __context.Centres
                        .Include(c => c.Ville)
                        .ToList();
        }

        public Centre GetCentreById(int id)
        {
            return __context.Centres.FirstOrDefault(p => p.IdCentre == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateCentre(Centre centre)
        {
            //Nothing
        }




    }
}