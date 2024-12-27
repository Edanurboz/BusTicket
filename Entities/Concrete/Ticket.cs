using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Ticket:IEntity
    {
        [Key]
        public int ticket_id { get; set; }
        public int trip_id { get; set; }
        public int user_id { get; set; }
        public bool is_cancelled { get; set; }
        public int seat_id { get; set; }
        public int bus_id { get; set; }
        public string Status { get; set; }


        public Trip Trip { get; set; }
        public User User { get; set; }
        public Seat Seat { get; set; }
        public Bus Bus { get; set; }
    }
}
