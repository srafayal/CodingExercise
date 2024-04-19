using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.Models
{
    public class FlightInventoryModel
    {
        private int flightNo;

        // Properties
        public List<ScheduleModel> Schedules { get; set; } // List to store ScheduleModel objects
        public FlightCity FlightCity { get; set; } // Instance of FlightCity
        
        /// <summary>
        /// Constructor
        /// </summary>
        public FlightInventoryModel()
        {
            FlightCity = new FlightCity();
            Schedules = new List<ScheduleModel>();
            flightNo=0;

            // Generate schedules for each day and arrival city
            for (int day = 1; day <= 2; day++)
            {
                foreach (CityModel arrival in FlightCity.ArrivalCity)
                {
                    flightNo = flightNo + 1;
                    Schedules.Add(new ScheduleModel() { FlightNo = flightNo, ArrivalCity = arrival, DepartureCity = FlightCity.DepartureCity, Day = day, Boxes=0 });
                }
            }
        }

        /// <summary>
        /// Method to display schedules
        /// </summary>
        public void ShowSchedule()
        {
            foreach (ScheduleModel schedule in Schedules)
            {
                // Construct output string
                string output = String.Format("Flight: {0}, departure: {1}, arrival: {2}, day: {3}", 
                                              schedule.FlightNo, schedule.DepartureCity.Id, 
                                              schedule.ArrivalCity.Id, schedule.Day);
                Console.WriteLine(output);

            }
        }
    }
}
