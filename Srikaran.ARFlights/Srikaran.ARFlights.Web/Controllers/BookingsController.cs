using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Srikaran.ARFlights.DomainEntities;
using Srikaran.ARFlights.Service.Commands;
using Srikaran.ARFlights.Service.Queries;
using Srikaran.ARFlights.Web.ViewModels;

namespace Srikaran.ARFlights.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Bookings")]
    public class BookingsController : Controller
    {
        private readonly IQueriesService _queries;
        private readonly ICommandsService _commands;

        private static IList<Booking> AllBookings { get; set; }
        List<VMListBookings> VMAllBookings = new List<VMListBookings>();

        public BookingsController(ICommandsService commands, IQueriesService queries)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));

            AllBookings = _queries.GetAllBookings();

            foreach (Booking b in AllBookings)
            {
                Flight f = _queries.GetFlightById(b.FlightNo);
                VMAllBookings.Add(new VMListBookings { FlightNo = b.FlightNo, ArrivalCity = f.ArrivalCity, BookingDate = b.BookingDate, DepartureCity = f.DepartureCity, EndTime = f.EndTime, BookingId = b.BookingId, PassengerName = b.PassengerId.ToString(), StartTime = f.StartTime });
            }
        }

        // GET api/bookings
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(VMAllBookings);
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // GET api/bookings/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(VMAllBookings.Where(b => b.BookingId == id).ToList());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // GET api/bookings/date
        [Route("[action]/{date}")]
        [HttpGet("{id}")]
        public IActionResult date(DateTime date)
        {
            try
            {
                return Ok(VMAllBookings.Where(b => b.BookingDate == date).ToList());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // GET api/bookings/flight/qa11
        [Route("[action]/{name}")]
        [HttpGet("{id}")]
        public IActionResult Flight(string flightNo)
        {
            try
            {
                if (flightNo == "")
                    return BadRequest();
                else
                    return Ok(VMAllBookings.Where(b => b.FlightNo.Equals(flightNo, StringComparison.CurrentCultureIgnoreCase)).ToList());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // GET api/bookings/passenger/john
        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult Passenger(string name)
        {
            try
            {
                return Ok(VMAllBookings.Where(b => b.PassengerName.Equals(name)).ToList());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // GET api/bookings/passenger/john
        [Route("[action]/{criteria}/{city}")]
        [HttpGet]
        public IActionResult Cities(string criteria, string city)
        {
            try
            {
                if (criteria.Equals("departure"))
                    return Ok(VMAllBookings.Where(b => b.DepartureCity.Equals(city)).ToList());
                else
                    return Ok(VMAllBookings.Where(b => b.ArrivalCity.Equals(city)).ToList());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        // POST api/bookings
        [HttpPost]
        public IActionResult Post([FromBody]VMNewBooking bookingRequest)
        {
            try
            {
                if (bookingRequest == null)
                    return BadRequest();
                else
                {
                    Booking newBooking = new Booking { BookingDate = bookingRequest.BookingDate, FlightNo = bookingRequest.FlightNo, Passenger = new Passenger() { PassengerName = bookingRequest.PassengerName } };
                    _commands.AddBooking(newBooking);
                    return Created("", newBooking);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}