using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class LogicielRepo : ILogicielRepo
    {
        private readonly GPIContext __context;

        public LogicielRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateLogiciel(Logiciel logiciel)
        {
            if (logiciel == null)
            {
                throw new ArgumentNullException(nameof(logiciel));
            }

            __context.Logiciels.Add(logiciel);
        }



        public void DeleteLogiciel(Logiciel logiciel)
        {
            if (logiciel == null)
            {
                throw new ArgumentNullException(nameof(logiciel));
            }
            __context.Logiciels.Remove(logiciel);
        }



        public IEnumerable<Logiciel> GetAllLogiciels()
        {
            return __context.Logiciels
                        .ToList();
        }

        public Logiciel GetLogicielById(int id)
        {
            return __context.Logiciels.FirstOrDefault(p => p.IdLogiciel == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateLogiciel(Logiciel logiciel)
        {
            //Nothing
        }




    }
}