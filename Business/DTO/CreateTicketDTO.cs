using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class CreateTicketDTO
    {
        public int trip_id { get; set; }
        public int user_id { get; set; }
        public bool is_cancelled { get; set; }
        public int seat_id { get; set; }
        public int bus_id { get; set; }
    }
}
