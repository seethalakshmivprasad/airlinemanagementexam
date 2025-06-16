using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineManagement.Model
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = "";
        public int CountryId { get; set; }
    }
}
