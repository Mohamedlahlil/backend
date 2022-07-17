using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Models;

namespace GPI.Data
{
    public class SqlFournisseurRepo : IFournisseurRepo
    {
        private readonly GPIContext _context;

        public SqlFournisseurRepo(GPIContext context)
        {
            _context = context;
        }

        public void CreateFournisseur(Fournisseur frn)
        {
            if (frn == null)
            {
                throw new ArgumentNullException(nameof(frn));
            }

            _context.Fournisseurs.Add(frn);
        }

        public void DeleteFournisseur(Fournisseur frn)
        {
            if (frn == null)
            {
                throw new ArgumentNullException(nameof(frn));
            }
            _context.Fournisseurs.Remove(frn);
        }

        public IEnumerable<Fournisseur> GetAllFournisseurs()
        {
            return _context.Fournisseurs.ToList();
        }

        public Fournisseur GetFournisseurById(int id)
        {
            return _context.Fournisseurs.FirstOrDefault(p => p.IdFournisseur == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateFournisseur(Fournisseur frn)
        {
            //Nothing
        }
    }
}