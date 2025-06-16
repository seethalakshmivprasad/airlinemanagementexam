using AirLineManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineManagement.Service
{
    internal interface IFlightservice
    {
        
        
            void ShowAllFlights();
            void SearchFlight(int id);
            void CreateFlight(Flight flight);
            void EditFlight(Flight flight);
        }
    }



