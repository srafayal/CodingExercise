using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Models
{
   public class FlightCity
   {
       public List<CityModel> ArrivalCity { get; set; }
       public CityModel DepartureCity { get; set; }

       public FlightCity()
        {
            ArrivalCity = new List<CityModel>();
            ArrivalCity.Add(new CityModel() { Id = "YYZ", Name = "Toronto" });
            ArrivalCity.Add(new CityModel() { Id = "YYC", Name = "Calgary" });
            ArrivalCity.Add(new CityModel() { Id = "YVR", Name = "Vancouver" });

            DepartureCity = new CityModel() { Id = "YUL", Name = "Montreal" };
        }
    }
}
