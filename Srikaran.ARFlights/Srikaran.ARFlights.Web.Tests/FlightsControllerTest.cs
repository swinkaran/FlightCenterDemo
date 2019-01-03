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
    public class FlightsControllerTest
    {
        #region Variables
        Service.Queries.IQueriesService _queries;
        FlightsController flightsController;
        DbContextOptionsBuilder contextBuilder;
        private const string ServiceBaseURL = "http://localhost:50875/";

        IList<Flight> flights;
        #endregion

        #region Test fixture setup
        [SetUp]
        public void Setup()
        {
            contextBuilder = InitializeDBContext();
            _queries = new Service.Queries.QueriesService(contextBuilder);
            flightsController = new Controllers.FlightsController(_queries);
            flights = _queries.GetAllFlights();
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
        public void GetAllFlightsTest()
        {
            Assert.IsTrue(flights.Count > 0);
        }

        [Test]
        public void GetPassengerCapacity()
        {
            //Every flight must have pasengercapacity
            int lightWithNoPassenger = flights.Where(f => f.PassengerCapacity < 1).ToList().Count;
            Assert.IsTrue(flights.Count > 0);
        }


        #endregion
    }
}
