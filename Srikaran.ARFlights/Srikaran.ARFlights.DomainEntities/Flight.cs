using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Srikaran.ARFlights.DomainEntities
{
    public class Flight
    {
        public Flight()
        {
            //Bookings = new HashSet<Booking>();
        }
        //[Key]
        //public int FlightId { get; set; }
        public string FlightNo { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int PassengerCapacity { get; set; }

        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }

        //public virtual ICollection<Booking> Bookings { get; set; }
    }
}
