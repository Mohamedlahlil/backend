using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class RoleuserRepo : IRoleuserRepo
    {
        private readonly GPIContext __context;

        public RoleuserRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateRoleuser(Roleuser roleuser)
        {
            if (roleuser == null)
            {
                throw new ArgumentNullException(nameof(roleuser));
            }

            __context.Roleusers.Add(roleuser);
        }



        public void DeleteRoleuser(Roleuser roleuser)
        {
            if (roleuser == null)
            {
                throw new ArgumentNullException(nameof(roleuser));
            }
            __context.Roleusers.Remove(roleuser);
        }



        public IEnumerable<Roleuser> GetAllRoleusers()
        {
            return __context.Roleusers
                        .Include(c => c.Role)
                        .Include(c => c.User)
                        .ToList();
        }

        public Roleuser GetRoleuserById(int id)
        {
            return __context.Roleusers.FirstOrDefault(p => p.IdRoleuser == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateRoleuser(Roleuser roleuser)
        {
            //Nothing
        }




    }
}