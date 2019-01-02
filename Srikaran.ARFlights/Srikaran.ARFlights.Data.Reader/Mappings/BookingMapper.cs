using FluentNHibernate.Mapping;
using Srikaran.ARFlights.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Srikaran.ARFlights.Data.Reader.Mappings
{
    public class BookingMapper : ClassMap<Booking>
    {
        public BookingMapper()
        {
            Id(b => b.BookingId);

            Map(b => b.BookingDate);
            Map(b => b.PassengerId);
            Map(b => b.FlightNo);
        }
    }
}
