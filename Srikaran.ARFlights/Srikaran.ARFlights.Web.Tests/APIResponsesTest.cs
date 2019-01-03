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
using System.Net.Http;
using System.Net;

namespace Srikaran.ARFlights.Web.Tests
{
    [TestFixture]
    public class APIResponsesTest
    {
        #region Variables
        private HttpClient client;
        private HttpResponseMessage response;
        private string basic_url;
        #endregion

        #region Setup
        [SetUp]
        public void SetUP()
        {
            basic_url = "";
            client = new HttpClient();
            client.BaseAddress = new Uri(basic_url);
        }
        #endregion

        #region Unit Tests
        [Test]
        public void GetAllBookingResponseSucces()
        {
            response = client.GetAsync("bookings").Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion
    }
}
