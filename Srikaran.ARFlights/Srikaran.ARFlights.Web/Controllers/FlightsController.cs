﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Srikaran.ARFlights.Service.Queries;
using Srikaran.ARFlights.DomainEntities;

namespace Srikaran.ARFlights.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Flights")]
    public class FlightsController : Controller
    {
        private readonly IQueriesService _queries;

        public FlightsController(IQueriesService queries)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        // GET api/flights
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_queries.GetAllFlights());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // GET api/flights/qa11
        [HttpGet("{no}")]
        public IActionResult Get(string no)
        {
            try
            {
                if (no == null || no == string.Empty)
                    return BadRequest();
                else
                    return Ok(_queries.GetFlightById(no));
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
        
        // GET api/flights/qa11
        [HttpGet("{flightno}/{start}/{end}")]
        public IActionResult Get(string flightNo, DateTime start, DateTime end)
        {
            try
            {
                if (start == null || end == null)
                    return BadRequest();
                else
                {
                    List<ViewModels.VMFlightsToBook> FlightsToBook = new List<ViewModels.VMFlightsToBook>();

                    IList<Booking> filteredBookings = _queries.GetBookingsByFlighNo(flightNo);
                    filteredBookings = _queries.FilterBookingsByDateRange(filteredBookings, start, end);
                    
                    Flight flight = _queries.GetFlightById(flightNo);

                    for (DateTime dt = start; dt <= end; dt = dt.AddDays(1))
                    {
                        ViewModels.VMFlightsToBook f = new ViewModels.VMFlightsToBook() { FlightNo = flightNo, DateToFly = dt, PassengerCapacity=flight.PassengerCapacity, SeatsLeft = this.GetSeatsLeft(flight, filteredBookings, dt) };
                        FlightsToBook.Add(f);
                    }
                    return Ok(FlightsToBook);
                }
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        [NonAction]
        private int GetSeatsLeft(Flight flight, IList<Booking> bookings, DateTime date)
        {
            int SeatsLeft = 0;
            SeatsLeft = flight.PassengerCapacity - bookings.Where(b => b.BookingDate == date).Count();
            return SeatsLeft;
        }
    }
}