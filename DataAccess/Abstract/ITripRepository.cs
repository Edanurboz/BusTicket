using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITripRepository : IEntityRepository<Trip>
    {
        List<Trip> GetTrips(string departureCity, string arrivalCity);
        Trip GetTripDetails(int trip_id);
    }
}
