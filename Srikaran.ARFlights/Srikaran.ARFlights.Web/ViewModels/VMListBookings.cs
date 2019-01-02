using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Srikaran.ARFlights.Web.ViewModels
{
    public class VMListBookings
    {
        public long BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string FlightNo { get; set; }
        public string PassengerName { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
    }
}
