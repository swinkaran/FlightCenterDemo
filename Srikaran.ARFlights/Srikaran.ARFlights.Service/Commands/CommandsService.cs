using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Srikaran.ARFlights.Data.Writer;
using Srikaran.ARFlights.DomainEntities;

namespace Srikaran.ARFlights.Service.Commands
{
    public class CommandsService : ICommandsService
    {
        FlightsDBContext context;

        public CommandsService(DbContextOptionsBuilder builder)
        {
            context = new FlightsDBContext(builder.Options);
        }

        public void AddBooking(Booking newBooking)
        {
            context.Add<Booking>(newBooking);
            context.SaveChanges();
        }
    }
}
