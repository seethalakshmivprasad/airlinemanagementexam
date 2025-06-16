using AirLineManagement.Model;

using AirLineManagement.Repository;
using System;

namespace AirLineManagement.Service
{
    public class FlightService : IFlightservice
    {
        private readonly IFlightrepo _repo;
        private string connectionString;

        public FlightService()
        {
            _repo = new Flightrepo(); // Alternatively use DI
        }

        public FlightService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ShowAllFlights()
        {
            var flights = _repo.GetAllFlights();
            foreach (var f in flights)
            {
                Console.WriteLine($"Flight {f.FlightId}: {f.DepAirportId} ➜ {f.ArrAirportId} on {f.DepDate.ToShortDateString()}");
            }
        }

        public void SearchFlight(int id)
        {
            var f = _repo.GetFlightById(id);
            if (f == null)
                Console.WriteLine("Flight not found.");
            else
                Console.WriteLine($"Found Flight: {f.FlightId} from {f.DepAirportId} ➜ {f.ArrAirportId}");
        }

        public void CreateFlight(Flight f) => _repo.AddFlight(f);

        public void EditFlight(Flight f) => _repo.UpdateFlight(f);
    }
}
