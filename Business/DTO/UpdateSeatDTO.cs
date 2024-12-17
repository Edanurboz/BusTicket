using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UpdateSeatDTO
    {
        public int seat_id { get; set; }
        public int seat_number { get; set; }
        public bool is_reserved { get; set; }
    }
}
