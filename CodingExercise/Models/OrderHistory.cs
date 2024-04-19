using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CodingExercise.Others;
using System.IO;
namespace CodingExercise.Models
{
    public class OrderHistory
    {
        public List<OrderBatchModel> OrderBatch { get; set; }// List to store OrderBatchModel objects

        public OrderHistory()
        {
        }
        /// <summary>
        /// Method to load orders from JSON file
        /// </summary>
        /// <param name="flightInventory"></param>
        public void LoadOrder(FlightInventoryModel flightInventory)
        {
            OrderBatch = new List<OrderBatchModel>(); // Initialize the list
            // Get the path to the JSON file relative to the executable directory
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/coding-assigment-orders.json");
            // Read the JSON file
            string json = File.ReadAllText(filePath);

            Dictionary<string, OrderModel> orders = JsonConvert.DeserializeObject<Dictionary<string, OrderModel>>(json);

            // Process each order
            foreach (var order in orders)
            {
                ScheduleModel schedule =flightInventory.Schedules
                    .Where(wh => wh.ArrivalCity.Id == order.Value.Destination && wh.Boxes < ApplicationSettings.BoxCapacity)
                    .OrderBy(or => or.Day)
                    .Take(1)
                    .SingleOrDefault();

                // If a schedule is found, update the schedule and add the order to OrderBatch
                if (schedule != null)
                {
                    schedule.Boxes = schedule.Boxes + 1;
                    OrderBatch.Add(new OrderBatchModel() { Schedule = schedule, OrderNo = order.Key });
                }
                else   // If no schedule is found, add the order to OrderBatch with null schedule
                {
                    OrderBatch.Add(new OrderBatchModel() { OrderNo = order.Key });
                }
            }
        }
        /// <summary>
        /// Method to display orders
        /// </summary>
        public void ShowOrder()
        {
            string output = "";
            foreach (var order in OrderBatch)
            {
                if (order.Schedule != null)
                {
                    output = String.Format("order: {0}, flightNumber: {1}, departure: {2}, arrival: {3}, day: {4}", order.OrderNo, order.Schedule.FlightNo, order.Schedule.DepartureCity.Id, order.Schedule.ArrivalCity.Id, order.Schedule.Day);
                }
                else
                {
                    output = String.Format("order: {0}, flightNumber: not scheduled",order.OrderNo );

                }
                    Console.WriteLine(output);
            }

        }
    }
}
