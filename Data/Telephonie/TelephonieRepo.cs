using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class TelephonieRepo : ITelephonieRepo
    {
        private readonly GPIContext __context;

        public TelephonieRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateTelephonie(Telephonie telephonie)
        {
            if (telephonie == null)
            {
                throw new ArgumentNullException(nameof(telephonie));
            }

            __context.Telephonies.Add(telephonie);
        }



        public void DeleteTelephonie(Telephonie telephonie)
        {
            if (telephonie == null)
            {
                throw new ArgumentNullException(nameof(telephonie));
            }
            __context.Telephonies.Remove(telephonie);
        }



        public IEnumerable<Telephonie> GetAllTelephonies()
        {
            return __context.Telephonies
                        .Include(c => c.AffTelephonie)
                        .ToList();
        }

        public Telephonie GetTelephonieById(int id)
        {
            return __context.Telephonies.FirstOrDefault(p => p.IdTelephonie == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateTelephonie(Telephonie telephonie)
        {
            //Nothing
        }




    }
}