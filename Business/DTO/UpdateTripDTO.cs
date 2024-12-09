using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UpdateTripDTO
    {
        public string departure_city { get; set; }
        public string arrival_city { get; set; }
        public int departure_time { get; set; }
        public int price { get; set; }
        public DateTime date_ { get; set; }
        public int bus_id { get; set; }
    }
}
