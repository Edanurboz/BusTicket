using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class CreateBusDTO
    {
        public string plate_number { get; set; }
        public string company { get; set; }
        public int trip_id { get; set; }
        public int price { get; set; }
        public int departure_time { get; set; }
    }
}
