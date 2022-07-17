using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class AffHistoriqueRepo : IAffHistoriqueRepo
    {
        private readonly GPIContext __context;

        public AffHistoriqueRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateAffHistorique(AffHistorique affHistorique)
        {
            if (affHistorique == null)
            {
                throw new ArgumentNullException(nameof(affHistorique));
            }

            __context.AffHistoriques.Add(affHistorique);
        }



        public void DeleteAffHistorique(AffHistorique affHistorique)
        {
            if (affHistorique == null)
            {
                throw new ArgumentNullException(nameof(affHistorique));
            }
            __context.AffHistoriques.Remove(affHistorique);
        }



        public IEnumerable<AffHistorique> GetAllAffHistoriques()
        {
            return __context.AffHistoriques
                        .Include(c => c.User)
                        .Include(c => c.Article)
                        .Include(c => c.Logiciel)
                        .Include(c => c.Telephonie)
                        .ToList();
        }

        public AffHistorique GetAffHistoriqueById(int id)
        {
            return __context.AffHistoriques.FirstOrDefault(p => p.IdHistorique == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateAffHistorique(AffHistorique affHistorique)
        {
            //Nothing
        }




    }
}