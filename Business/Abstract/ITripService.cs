using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITripService
    {
        void Create(Trip trip);
        void UpdateTrip(Trip trip);
        void DeleteTrip(Trip trip);
        Trip GetTripById(int id);
        List<Trip> GetAllTrips();
        List<Trip> GetTrips(string departureCity, string arrivalCity);
        Trip GetTripDetails(int tripId);
    }
}
