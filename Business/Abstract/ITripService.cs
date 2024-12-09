using Business.DTO;
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
        string Create(CreateTripDTO trip);
        void UpdateTrip(UpdateTripDTO trip);
        void DeleteTrip(DeleteTripDTO trip);
        Trip GetTripById(int id);
        List<Trip> GetAllTrips();
        List<Trip> GetTrips(string departureCity, string arrivalCity);
        Trip GetTripDetails(int tripId);
    }
}
