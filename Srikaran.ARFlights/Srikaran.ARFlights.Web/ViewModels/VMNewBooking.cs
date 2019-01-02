using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Srikaran.ARFlights.Web.ViewModels
{
    public class VMNewBooking
    {
        public DateTime BookingDate { get; set; }
        public string FlightNo { get; set; }
        public string PassengerName { get; set; }
    }
}
