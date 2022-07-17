using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly GPIContext __context;

        public UserRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            __context.Users.Add(user);
        }



        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            __context.Users.Remove(user);
        }



        public IEnumerable<User> GetAllUsers()
        {
            return __context.Users
                        .Include(c => c.Service)
                        .ToList();
        }

        public User GetUserById(int id)
        {
            return __context.Users.FirstOrDefault(p => p.IdUser == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {
            //Nothing
        }

        
    }
}