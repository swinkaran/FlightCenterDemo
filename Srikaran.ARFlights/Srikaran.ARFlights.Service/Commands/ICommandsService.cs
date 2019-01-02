using Srikaran.ARFlights.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Srikaran.ARFlights.Service.Commands
{
    public interface ICommandsService
    {
        void AddBooking(Booking newBooking);
    }
}
