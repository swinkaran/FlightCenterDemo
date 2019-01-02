using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Srikaran.ARFlights.DomainEntities;

namespace Srikaran.ARFlights.Data.Writer
{
    public class FlightsDBContext : DbContext
    {
        public FlightsDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Passenger[] passengers = new Passenger[] {
            new Passenger() { PassengerId = 111, PassengerName = "Steven" }, new Passenger() { PassengerId = 112, PassengerName = "Adrian" }, new Passenger() { PassengerId = 113, PassengerName = "John" },
                new Passenger() { PassengerId = 114, PassengerName = "Ella" }, new Passenger() { PassengerId = 115, PassengerName = "Chris" }, new Passenger() { PassengerId = 116, PassengerName = "Rayna" },
                   new Passenger() { PassengerId = 117, PassengerName = "Ada" }, new Passenger() { PassengerId = 118, PassengerName = "Brian" }, new Passenger() { PassengerId = 119, PassengerName = "Devon" },
                      new Passenger() { PassengerId = 120, PassengerName = "Joy" }, new Passenger() { PassengerId = 121, PassengerName = "Luke" }, new Passenger() { PassengerId = 122, PassengerName = "Mohammad" },
                         new Passenger() { PassengerId = 123, PassengerName = "Jamiya" }, new Passenger() { PassengerId = 124, PassengerName = "Deshawn" }, new Passenger() { PassengerId = 125, PassengerName = "Precious" },
                            new Passenger() { PassengerId = 126, PassengerName = "Julie" }, new Passenger() { PassengerId = 127, PassengerName = "Rafael" }, new Passenger() { PassengerId = 128, PassengerName = "Zara" },
                               new Passenger() { PassengerId = 129, PassengerName = "Chris" }, new Passenger() { PassengerId = 130, PassengerName = "Jesse" }, new Passenger() { PassengerId = 131, PassengerName = "Angelica" },
            };

            modelBuilder.Entity<Passenger>().HasData(passengers);

            modelBuilder.Entity<Booking>().HasData(
                new Booking() { BookingId = 1, BookingDate = DateTime.Today.AddDays(30), FlightNo = "QA11", PassengerId = 111 }, new Booking() { BookingId = 11, BookingDate = DateTime.Today.AddDays(30), FlightNo = "QA11", PassengerId = 112 },
                new Booking() { BookingId = 2, BookingDate = DateTime.Today.AddDays(30), FlightNo = "VM24", PassengerId = 113 }, new Booking() { BookingId = 12, BookingDate = DateTime.Today.AddDays(30), FlightNo = "QA201", PassengerId = 114 },
                new Booking() { BookingId = 3, BookingDate = DateTime.Today.AddDays(30), FlightNo = "QA201", PassengerId = 115 }, new Booking() { BookingId = 13, BookingDate = DateTime.Today.AddDays(31), FlightNo = "QA11", PassengerId = 116 },
                new Booking() { BookingId = 4, BookingDate = DateTime.Today.AddDays(30), FlightNo = "VM24", PassengerId = 117 }, new Booking() { BookingId = 14, BookingDate = DateTime.Today.AddDays(31), FlightNo = "QA201", PassengerId = 118 },
                new Booking() { BookingId = 5, BookingDate = DateTime.Today.AddDays(31), FlightNo = "VM24", PassengerId = 119 }, new Booking() { BookingId = 15, BookingDate = DateTime.Today.AddDays(32), FlightNo = "QA11", PassengerId = 120 },
                new Booking() { BookingId = 6, BookingDate = DateTime.Today.AddDays(31), FlightNo = "VM24", PassengerId = 121 }, new Booking() { BookingId = 16, BookingDate = DateTime.Today.AddDays(33), FlightNo = "QA201", PassengerId = 122 },
                new Booking() { BookingId = 7, BookingDate = DateTime.Today.AddDays(32), FlightNo = "QA201", PassengerId = 123 }, new Booking() { BookingId = 17, BookingDate = DateTime.Today.AddDays(33), FlightNo = "QA201", PassengerId = 124 },
                new Booking() { BookingId = 8, BookingDate = DateTime.Today.AddDays(33), FlightNo = "VM24", PassengerId = 125 }, new Booking() { BookingId = 18, BookingDate = DateTime.Today.AddDays(34), FlightNo = "QA201", PassengerId = 126 },
                new Booking() { BookingId = 9, BookingDate = DateTime.Today.AddDays(33), FlightNo = "VM24", PassengerId = 127 }, new Booking() { BookingId = 19, BookingDate = DateTime.Today.AddDays(35), FlightNo = "QA11", PassengerId = 128 },
                new Booking() { BookingId = 10, BookingDate = DateTime.Today.AddDays(33), FlightNo = "QA201", PassengerId = 129 }, new Booking() { BookingId = 20, BookingDate = DateTime.Today.AddDays(35), FlightNo = "QA201", PassengerId = 130 }
                );
        }
    }
}
