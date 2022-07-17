using System;
using System.Collections.Generic;
using System.Linq;
using GPI.Data;
using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class TicketRepo : ITicketRepo
    {
        private readonly GPIContext __context;

        public TicketRepo(GPIContext context)
        {
            __context = context;
        }

        public void CreateTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            __context.Tickets.Add(ticket);
        }



        public void DeleteTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }
            __context.Tickets.Remove(ticket);
        }



        public IEnumerable<Ticket> GetAllTickets()
        {
            return __context.Tickets
                        .Include(c => c.User)
                        .Include(c => c.Article)
                        .Include(c => c.Logiciel)
                        .Include(c => c.Telephonie)
                        .Include(c => c.SousCategorie)
                        .ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return __context.Tickets.FirstOrDefault(p => p.IdTicket == id);
        }

        public bool SaveChanges()
        {
            return (__context.SaveChanges() >= 0);
        }

        public void UpdateTicket(Ticket ticket)
        {
            //Nothing
        }




    }
}