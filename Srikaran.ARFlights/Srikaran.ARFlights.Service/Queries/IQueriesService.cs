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
        IList<Flight> GetFlightsByDates(DateTime start, DateTime end);


        IList<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        IList<Booking> GetBookingByPassengerName(string passengerName);
        IList<Booking> GetBookingByDepartureCity(string departureCity);
        IList<Booking> GetBookingByArrivalCity(string arrivalCity);
        IList<Booking> GetBookingByDate(DateTime bookingDate);
    }
}
