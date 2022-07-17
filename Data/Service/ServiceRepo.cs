using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly GPIContext __context;

        public ServiceRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateService(Service service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            __context.Services.Add(service);
        }



        public void DeleteService(Service service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }
            __context.Services.Remove(service);
        }



        public IEnumerable<Service> GetAllServices()
        {
            return __context.Services
                        .Include(c => c.Centre)
                        .ToList();
        }

        public Service GetServiceById(int id)
        {
            return __context.Services.FirstOrDefault(p => p.IdService == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateService(Service service)
        {
            //Nothing
        }




    }
}