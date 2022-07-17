using System.Collections.Generic;
using GPI.Models;

namespace GPI.Data
{
    public interface ITicketRepo
    {
        bool SaveChanges();
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        void CreateTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
    }
}