using Business.Abstract;
using Business.DTO;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SeatManager : ISeatService
    {
        ISeatRepository _seatRepository;

        public SeatManager(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public string Create(CreateSeatDTO seat)
        {
           var newSeat=new Seat();
            newSeat.seat_number = seat.seat_number;
            newSeat.is_reserved = seat.is_reserved;
            newSeat.bus_id = seat.bus_id;
            _seatRepository.Create(newSeat);
            return "Koltuk başarıyla eklendi.";
        }



        public void Delete(DeleteSeatDTO seat)
        {
            var newSeat = new Seat();
            newSeat.seat_id=seat.seat_id;
        }


        public List<Seat> GetAll()
        {
            //iş kodları
            return _seatRepository.GetAll();
        }


        public Seat GetById(int id)
        {
            return _seatRepository.Get(s => s.seat_id == id);
        }

        public Seat GetSeatDetails(int seatId)
        {
            return _seatRepository.GetSeatDetails(seatId);
        }

        public void ReleaseSeat(int seatId)
        {
            var seat = _seatRepository.Get(s => s.seat_id == seatId);
            if (seat != null)
            {
                seat.is_reserved = false;
                _seatRepository.Update(seat);
            }
            else
            {
                throw new ArgumentException("Seat not found");
            }
        }

        public void ReserveSeat(int seatId)
        {
            var seat = _seatRepository.Get(s => s.seat_id == seatId);
            if (seat != null)
            {
                seat.is_reserved = true;
                _seatRepository.Update(seat);
            }
            else
            {
                throw new ArgumentException("Seat not found");
            }
        }

        public void Update(UpdateSeatDTO seat)
        {
            var newSeat= new Seat();
            newSeat.seat_id= seat.seat_id;
            newSeat.seat_number = seat.seat_number;
            newSeat.is_reserved=seat.is_reserved;
            _seatRepository.Update(newSeat);
        }
    }
}
