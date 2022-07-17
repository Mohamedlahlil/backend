using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class AffTelephonieRepo : IAffTelephonieRepo
    {
        private readonly GPIContext __context;

        public AffTelephonieRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateAffTelephonie(AffTelephonie affTelephonie)
        {
            if (affTelephonie == null)
            {
                throw new ArgumentNullException(nameof(affTelephonie));
            }

            __context.AffTelephonies.Add(affTelephonie);
        }



        public void DeleteAffTelephonie(AffTelephonie affTelephonie)
        {
            if (affTelephonie == null)
            {
                throw new ArgumentNullException(nameof(affTelephonie));
            }
            __context.AffTelephonies.Remove(affTelephonie);
        }



        public IEnumerable<AffTelephonie> GetAllAffTelephonies()
        {
            return __context.AffTelephonies
                        .Include(c => c.Centre)
                        .ToList();
        }

        public AffTelephonie GetAffTelephonieById(int id)
        {
            return __context.AffTelephonies.FirstOrDefault(p => p.IdAffTelephonie == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateAffTelephonie(AffTelephonie affTelephonie)
        {
            //Nothing
        }

       
    }
}