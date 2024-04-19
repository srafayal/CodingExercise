using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Models
{
    public class ScheduleModel
    {
        public int FlightNo { get; set; }
        public CityModel ArrivalCity { get; set; }
        public CityModel DepartureCity { get; set; }
        public int Day { get; set; }
        public int Boxes { get; set; }
    }
}
