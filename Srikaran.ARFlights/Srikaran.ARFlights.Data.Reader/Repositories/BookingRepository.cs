using NHibernate;
using Srikaran.ARFlights.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Srikaran.ARFlights.Data.Reader.Repositories
{
    public class BookingRepository
    {
        public IList<Booking> GetAll()
        {
            List<string> names = new List<string>();
            IList<Booking> bookings;
            IList<Passenger> passengers;

            // create our NHibernate session factory
            string connectionString = " server=BW-DESKTOP\\SQLEXPRESS2014; database=FlightsDB;Trusted_Connection=True;";
            var sessionFactory = SessionFactoryBuilder.BuildSessionFactory(connectionString, true, true);
            
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    bool isopen = session.IsOpen;
                    bool isconnected = session.IsConnected;

                    passengers = session.Query<Passenger>().ToList();

                    bookings = session.Query<Booking>().ToList(); //  Querying to get all the books

                    foreach (var b in bookings)
                    {
                        names.Add(b.FlightNo);  
                    }
                }
            }

            return bookings;
        }
    }
}
