using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISeatRepository : IEntityRepository<Seat>
    {
       
        Seat GetSeatDetails(int seatId);
        void ReserveSeat(int seatId);
        void ReleaseSeat(int seatId);
    }
}
