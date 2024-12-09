using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Bus : IEntity
    {
        [Key]
        public int bus_id { get; set; }
        public string plate_number { get; set; }
        public string company { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
