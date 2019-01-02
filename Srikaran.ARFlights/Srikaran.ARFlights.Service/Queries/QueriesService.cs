using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Srikaran.ARFlights.Data.Reader.Repositories;
using Srikaran.ARFlights.Data.Writer;
using Srikaran.ARFlights.DomainEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Srikaran.ARFlights.Service.Queries
{
    /// <summary>
    /// This is responsible for reading the data out from the database. No write functionality within the scope of this service
    /// </summary>
    public class QueriesService : IQueriesService
    {
        FlightsDBContext context;

        public QueriesService(DbContextOptionsBuilder builder)
        {
            context = new FlightsDBContext(builder.Options);
        }

        #region Flights
        public IList<Flight> GetAllFlights()
        {
            // This method should load the flights from a csv files
            string filePath = @"allflights.csv";
            IList<Flight> flights;

            using (var reader = new StreamReader(filePath))
            using (var cv = new CsvReader(reader))
            {
                flights = cv.GetRecords<Flight>().ToList();
            }

            return flights;
        }

        public Flight GetFlightById(string flightNo)
        {
            return this.GetAllFlights().Where(f => f.FlightNo.Equals(flightNo, StringComparison.CurrentCultureIgnoreCase)).First();
        }

        public IList<Flight> GetFlightsByDates(DateTime start, DateTime end)
        {

            for (DateTime dt = start; dt <= end; dt.AddDays(1))
            {

            }
            throw new NotImplementedException();
        }
        #endregion

        #region Bookings
        public IList<Booking> GetAllBookings()
        {
            IList<Booking> bookings;
            bookings = context.Bookings.ToList();
            return bookings;
        }

        public Booking GetBookingById(int id)
        {
            Booking booking;
            booking = context.Bookings.Where(b => b.BookingId == id).First();
            return booking;
        }

        public IList<Booking> GetBookingByPassengerName(string passengerName)
        {
            throw new NotImplementedException();
        }

        public IList<Booking> GetBookingByDepartureCity(string departureCity)
        {
            throw new NotImplementedException();
        }

        public IList<Booking> GetBookingByArrivalCity(string arrivalCity)
        {
            throw new NotImplementedException();
        }

        public IList<Booking> GetBookingByDate(DateTime bookingDate)
        {
            return context.Bookings.Where(b => b.BookingDate.ToShortDateString() == bookingDate.ToShortDateString()).ToList();
        }
        #endregion
    }
}
