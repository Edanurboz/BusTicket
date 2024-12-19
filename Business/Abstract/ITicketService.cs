using Business.DTO;
using Core;
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
        string CreateTicket(CreateTicketDTO ticket);
        void UpdateTicket(UpdateTicketDTO ticket);
        void DeleteTicket(DeleteTicketDTO ticket);
        Ticket GetTicketById(int id);
        List<Ticket> GetAllTickets();
        List<Ticket> GetTicketsByTripId(int tripId);
        List<Core.TicketDTO> GetTicketDetails(int userId);
        void CancelTicket(int ticketId);
    }
}
