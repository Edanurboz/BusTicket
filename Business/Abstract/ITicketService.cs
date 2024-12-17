using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITicketService
    {
        void CreateTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
        Ticket GetTicketById(int id);
        List<Ticket> GetAllTickets();
        List<Ticket> GetTicketsByTripId(int tripId);
        Ticket GetTicketDetails(int ticketId);
        void CancelTicket(int ticketId);
    }
}
