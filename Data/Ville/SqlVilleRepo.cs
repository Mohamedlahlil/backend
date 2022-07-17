using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;

namespace GPI.Data
{
    public class SqlVilleRepo : IVilleRepo
    {
        private readonly GPIContext __context;

        public SqlVilleRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateVille(Ville vl)
        {
            if (vl == null)
            {
                throw new ArgumentNullException(nameof(vl));
            }

            __context.villes.Add(vl);
        }



        public void DeleteVille(Ville vl)
        {
            if (vl == null)
            {
                throw new ArgumentNullException(nameof(vl));
            }
            __context.villes.Remove(vl);
        }



        public IEnumerable<Ville> GetAllVilles()
        {
            return __context.villes.ToList();
        }

        public Ville GetVilleById(int id)
        {
            return __context.villes.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateVille(Ville vl)
        {
            //Nothing
        }




    }
}