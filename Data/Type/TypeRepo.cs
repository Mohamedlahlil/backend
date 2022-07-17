using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class TypeRepo : ITypeRepo
    {
        private readonly GPIContext __context;

        public TypeRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateType(Models.Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            __context.Types.Add(type);
        }


        public void DeleteType(Models.Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            __context.Types.Remove(type);
        }

        

        public IEnumerable<Models.Type> GetAllTypes()
        {
            return __context.Types.ToList();
        }

        public Models.Type GetTypeById(int id)
        {
            return __context.Types.FirstOrDefault(p => p.IdType == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateType(Models.Type type)
        {
            //Nothing
        }

        
    }
}