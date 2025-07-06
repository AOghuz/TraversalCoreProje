using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservationn
    {
        public int? Id { get; set; }
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string? PersonCount { get; set; }
        //public string Destination { get; set; }
        public DateTime? RezervasyonDate { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }

        public int DestinationId { get; set; }
        public Destination? Destination { get; set; }
    }
}
