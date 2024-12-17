using Business.Abstract;
using Business.DTO;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BusManager : IBusService
    {
        IBusRepository _busRepository;
        public BusManager(IBusRepository busRepository)
        {
            _busRepository = busRepository;

        }
        public string Create(CreateBusDTO bus)
        {
            var newBus= new Bus();
            newBus.plate_number = bus.plate_number;
            newBus.company=bus.company;
            newBus.price = bus.price;
            newBus.departure_time = bus.departure_time;
            newBus.trip_id = bus.trip_id;
            _busRepository.Create(newBus);
            return "Otobüs başarıyla eklendi.";
        }

        public void Delete(DeleteBusDTO bus)
        {
            var newBus=new Bus();
            newBus.bus_id=bus.bus_id;
        }

        public List<Bus> GetAll()
        {
            return _busRepository.GetAll();
        }

        public object GetBusById(int id)
        {
            var bus = _busRepository.Get(u => u.bus_id == id);
            if (bus == null)
            {
                throw new KeyNotFoundException("Bu kullanıcı bulunamadı.");
            }
            return bus;
        }

        public void Update(UpdateBusDTO bus)
        {
            var newBus = new Bus();
            newBus.bus_id = bus.bus_id;
            newBus.plate_number = bus.plate_number;
            newBus.company = bus.company;
            newBus.price = bus.price;
            newBus.departure_time = bus.departure_time;
            newBus.trip_id = bus.trip_id;
            _busRepository.Update(newBus);
        }
    }
}
