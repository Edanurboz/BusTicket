using Core;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class TicketRepository : EfEntityRepositoryBase<Ticket, BiletOtomasyonu>, ITicketRepository

    {
        private readonly BiletOtomasyonu _context;

        public TicketRepository(BiletOtomasyonu context)
        {
            _context = context;
        }

        public void CancelTicket(int ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);
            if (ticket != null)
            {
                ticket.is_cancelled = true;
                _context.SaveChanges();
            }
        }


        public List<TicketDTO> GetTicketDetails(int userId)
        {
             var ticketDetails = (from tk in _context.Tickets
                                  join u in _context.Users on tk.user_id equals u.user_id
                                  join t in _context.Trips on tk.trip_id equals t.trip_id
                                  join b in _context.Buses on tk.bus_id equals b.bus_id
                                  join s in _context.Seats on tk.seat_id equals s.seat_id
                                  where tk.is_cancelled == false
                                        && tk.user_id == userId
                                  select new TicketDTO
                             {
                                 name = u.name,
                                 surname = u.surname,
                                 departure_city = t.departure_city,
                                 arrival_city = t.arrival_city,
                                 date_ = t.date_,
                                 plate_number = b.plate_number,
                                 seat_number = s.seat_number
                             }).ToList();

        return ticketDetails;
        }

        public List<Ticket> GetTicketsByTripId(int tripId)
        {
            return _context.Tickets
                           .Where(t => t.trip_id == tripId)
                           .ToList();
        }


    }
}
