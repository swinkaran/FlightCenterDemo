using Srikaran.ARFlights.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Srikaran.ARFlights.Service.Queries
{
    public interface IQueriesService
    {
        IList<Flight> GetAllFlights();
        Flight GetFlightById(string flightNo);
        
        IList<Booking> GetAllBookings();
        IList<Booking> GetBookingsByFlighNo(string flightNo);
        IList<Booking> FilterBookingsByDateRange(IList<Booking> bookings, DateTime start, DateTime end);
    }
}
