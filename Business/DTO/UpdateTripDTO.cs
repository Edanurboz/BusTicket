using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UpdateTripDTO
    {
        public int trip_id { get; set; }
        public string departure_city { get; set; }
        public string arrival_city { get; set; }
        public DateTime date_ { get; set; }
    }
}
