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
        #endregion

        #region Bookings
        public IList<Booking> GetAllBookings()
        {
            IList<Booking> bookings;
            bookings = context.Bookings.ToList();
            return bookings;
        }
        
        public IList<Booking> GetBookingsByFlighNo(string flightNo)
        {
            return context.Bookings.Where(b => b.FlightNo.Equals(flightNo, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public IList<Booking> FilterBookingsByDateRange(IList<Booking> bookings, DateTime start, DateTime end)
        {
            return bookings.Where(d => (d.BookingDate >= start && d.BookingDate <= end)).ToList();
        }
        #endregion
    }
}
