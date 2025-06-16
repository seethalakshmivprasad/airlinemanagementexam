using AirLineManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineManagement.Repository
{public interface IFlightrepo
    {

        List<Flight> GetAllFlights();
        Flight? GetFlightById(int id);
        void AddFlight(Flight flight);
        void UpdateFlight(Flight flight);
    }
}
