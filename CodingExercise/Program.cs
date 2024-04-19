using CodingExercise.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace CodingExercise
{
   public  class Program
    {
       public static void Main(string[] args)
       {
           FlightInventoryModel flightInventory = new FlightInventoryModel(); // Create a new instance of FlightInventoryModel
           Console.WriteLine("Printing the loaded flight schedule...");
           Console.WriteLine("***************************************************");
           flightInventory.ShowSchedule(); // Display the loaded flight schedule
           Console.WriteLine("***************************************************");


           OrderHistory orderHistory = new OrderHistory(); // Create a new instance of OrderHistory
           orderHistory.LoadOrder(flightInventory); // Load orders based on flight schedules

           Console.WriteLine("Printing the current order logs");
           Console.WriteLine("***************************************************");
           orderHistory.ShowOrder(); // Display the current order logs
           Console.WriteLine("***************************************************");

           Console.ReadLine(); // Waits for the user to press Enter
           Console.WriteLine("Enter key pressed. Program exiting...");


        }
    }
}
