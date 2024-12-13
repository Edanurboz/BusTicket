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
    public class SeatRepository : EfEntityRepositoryBase<Seat, BiletOtomasyonu>, ISeatRepository
    {
        private readonly BiletOtomasyonu _context;

        public SeatRepository(BiletOtomasyonu context)
        {
            _context = context;
        }

        

        public Seat GetSeatDetails(int seatId)
        {
            return _context.Seats.Include(s => s.Bus).FirstOrDefault(s => s.seat_id == seatId);
        }

        public void ReleaseSeat(int seatId)
        {
            var seat = _context.Seats.Find(seatId);
            if (seat != null)
            {
                seat.is_reserved = false;
                _context.SaveChanges();
            }
        }

        public void ReserveSeat(int seatId)
        {
            var seat = _context.Seats.Find(seatId);
            if (seat != null)
            {
                seat.is_reserved = true;
                _context.SaveChanges();
            }
        }


    }
}
