using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITicketRepository : IEntityRepository<Ticket>
    {
        List<Ticket> GetTicketsByTripId(int tripId);
        Ticket GetTicketDetails(int ticketId);
        void CancelTicket(int ticketId);
    }

}
