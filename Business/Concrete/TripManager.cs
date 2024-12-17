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
    public class TripManager : ITripService
    {
        ITripRepository _tripRepository;

        // Dependency injection ile ITripRepository nesnesini alıyoruz
        public TripManager(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public string Create(CreateTripDTO trip)
        {
           var newTrip= new Trip();
            newTrip.arrival_city = trip.arrival_city;
            newTrip.departure_city = trip.departure_city;
            newTrip.date_= trip.date_;
            _tripRepository.Create(newTrip);

            return "Seyehat ekleme başarılı";
        }

        public void DeleteTrip(DeleteTripDTO trip)
        {

            var newTrip = new Trip();
            newTrip.trip_id = trip.trip_id;
        }

        public List<Trip> GetAllTrips()
        {
            return _tripRepository.GetAll();
        }

        public Trip GetTripById(int id)
        {
            return _tripRepository.Get(tr => tr.trip_id == id);
        }

        public Trip GetTripDetails(int tripId)
        {
            return _tripRepository.GetTripDetails(tripId);
        }

        public List<Trip> GetTrips(string departureCity, string arrivalCity)
        {
            if (!string.IsNullOrEmpty(departureCity) && !string.IsNullOrEmpty(arrivalCity))
            {
                return _tripRepository.GetTrips(departureCity, arrivalCity);
            }
            else
            {
                throw new ArgumentException("Departure and arrival cities must be specified");
            }
        }

        public void UpdateTrip(UpdateTripDTO trip)
        {

            var newTrip = new Trip();
            newTrip.arrival_city = trip.arrival_city;
            newTrip.departure_city = trip.departure_city;
            newTrip.date_ = trip.date_;
            _tripRepository.Update(newTrip);
        }
    }
}
