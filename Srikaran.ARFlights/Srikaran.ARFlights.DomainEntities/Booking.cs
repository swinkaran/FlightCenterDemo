using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Srikaran.ARFlights.DomainEntities
{
    public class Booking
    {
        public Booking()
        {
        }

        public long BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string FlightNo { get; set; }
        public int PassengerId { get; set; }

        //// Navigation properties
        //[ForeignKey("FlightId")]
        //public virtual Flight Flight { get; set; }
        [ForeignKey("PassengerId")]
        public virtual Passenger Passenger { get; set; }
    }
}