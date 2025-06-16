using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineManagement.Model
{
 public class Airport
    {
        public int AirportId { get; set; }
        public string AirportCode { get; set; } = "";
        public string AirportName { get; set; } = "";
        public int CityId { get; set; }
    }
}
