using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TicketDTO
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string departure_city { get; set; }
        public string arrival_city { get; set; }
        public DateTime date_ { get; set; }
        public string plate_number { get; set; }
        public int seat_number { get; set; }
    }
}
