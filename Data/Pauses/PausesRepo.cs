using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class PausesRepo : IPausesRepo
    {
        private readonly GPIContext __context;

        public PausesRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreatePauses(Pauses pauses)
        {
            if (pauses == null)
            {
                throw new ArgumentNullException(nameof(pauses));
            }

            __context.Pausess.Add(pauses);
        }



        public void DeletePauses(Pauses pauses)
        {
            if (pauses == null)
            {
                throw new ArgumentNullException(nameof(pauses));
            }
            __context.Pausess.Remove(pauses);
        }



        public IEnumerable<Pauses> GetAllPausess()
        {
            return __context.Pausess
                        .Include(c => c.Ticket)
                        .ToList();
        }

        public Pauses GetPausesById(int id)
        {
            return __context.Pausess.FirstOrDefault(p => p.IdPauses == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdatePauses(Pauses pauses)
        {
            //Nothing
        }




    }
}