using Business.DTO;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISeatService
    {
        //burada istediğini yaz fiyat aralığı vs
        string Create(CreateSeatDTO seat); 
        void Update(UpdateSeatDTO seat);
        void Delete(DeleteSeatDTO seat);
        Seat GetById(int id);
        List<Seat> GetAll();
        Seat GetSeatDetails(int seatId);
        void ReserveSeat(int seatId);
        void ReleaseSeat(int seatId);
    }
}
