using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class CreateSeatDTO
    {

        public int seat_number { get; set; }
        public bool is_reserved { get; set; }
        public int bus_id { get; set; }
    }
}
