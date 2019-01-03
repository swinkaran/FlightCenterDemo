using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Srikaran.ARFlights.Web;
using Srikaran.ARFlights.Service;
using Srikaran.ARFlights.DomainEntities;
using Srikaran.ARFlights.Web.Controllers;
using Microsoft.EntityFrameworkCore;
using Srikaran.ARFlights.Data.Writer;
using System.Linq;

namespace Srikaran.ARFlights.Web.Tests
{
    [TestFixture]
    public class BookingsControllerTest
    {
        #region Variables
        Service.Queries.IQueriesService _queries;
        Service.Commands.ICommandsService _commands;
        BookingsController bookingsController;
        DbContextOptionsBuilder contextBuilder;
        private const string ServiceBaseURL = "http://localhost:50875/";

        IList<Booking> bookings;
        #endregion

        #region Test fixture setup
        [SetUp]
        public void Setup()
        {
            contextBuilder = InitializeDBContext();
            _queries = new Service.Queries.QueriesService(contextBuilder);
            _commands = new Service.Commands.CommandsService(contextBuilder);
            bookingsController = new Controllers.BookingsController(_commands, _queries);
            bookings = _queries.GetAllBookings();
        }
        
        private DbContextOptionsBuilder InitializeDBContext()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<FlightsDBContext>();
            builder.UseSqlServer("server=SRIKARAN\\SQLTEEHEE; database=FlightsDB915;Trusted_Connection=True;");
            return builder;
        }
        #endregion

        #region Setup
        #endregion

        #region Unit Tests
        [Test]
        public void GetAllBookingsTest()
        {
            Assert.IsTrue(bookings.Count > 0);
        }

        [Test]
        public void GetBookingByFlightTest()
        {
            int NoOfBookingWithNoFlight = bookings.Where(b => b.FlightNo == null).ToList().Count;
            Assert.IsTrue(NoOfBookingWithNoFlight == 0);
        }
        
        #endregion
    }
}
