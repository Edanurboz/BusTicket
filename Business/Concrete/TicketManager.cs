using Business.Abstract;
using Business.DTO;
using Core;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TicketManager : ITicketService
    {
        ITicketRepository _ticketRepository;

        public TicketManager(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void CancelTicket(int ticketId)
        {
            var ticket = _ticketRepository.Get(t => t.ticket_id == ticketId);
            if (ticket != null)
            {
                ticket.is_cancelled = true;
                _ticketRepository.Update(ticket);
            }
            else
            {
                throw new ArgumentException("Ticket not found");
            }
        }

        public string CreateTicket(CreateTicketDTO ticket)
        {
            var newTicket = new Ticket();
            
            newTicket.trip_id = ticket.trip_id;
            newTicket.user_id = ticket.user_id;
            newTicket.is_cancelled = false;
            newTicket.seat_id = ticket.seat_id;
            newTicket.bus_id = ticket.bus_id;
            _ticketRepository.Create(newTicket);
            return "Koltuk başarıyla eklendi.";
        }

        public void DeleteTicket(DeleteTicketDTO ticket)
        {
            var newTicket = new Ticket();
            newTicket.ticket_id = ticket.ticket_id;
            _ticketRepository.Delete(newTicket);
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll();
        }

        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.Get(t => t.ticket_id == id);
        }

        public List<Core.TicketDTO> GetTicketDetails(int userId)
        {
            return _ticketRepository.GetTicketDetails(userId);
        }

        public List<Ticket> GetTicketsByTripId(int tripId)
        {
            return _ticketRepository.GetTicketsByTripId(tripId);
        }

        public void UpdateTicket(UpdateTicketDTO ticket)
        {
            var newTicket = new Ticket();
            newTicket.ticket_id = ticket.ticket_id;
            newTicket.trip_id = ticket.trip_id;
            newTicket.user_id = ticket.user_id;
            newTicket.is_cancelled = false;
            newTicket.seat_id = ticket.seat_id;
            newTicket.bus_id = ticket.bus_id;
            _ticketRepository.Update(newTicket);
        }
    }
}
