// Program.cs
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Create a list of the base type Activity (Demonstrating polymorphism)
        List<Activity> fitnessLog = new List<Activity>
        {
            // Running: Stores distance
            new Running(
                date: new DateTime(2022, 11, 3),
                durationMinutes: 30.0,
                distanceMiles: 3.0
            ),
            // Cycling: Stores speed
            new StationaryBicycles(
                date: new DateTime(2022, 11, 3),
                durationMinutes: 45.0,
                recordedSpeedMph: 15.0
            ),
            // Swimming: Stores laps
            new Swimming(
                date: new DateTime(2022, 11, 4),
                durationMinutes: 60.0,
                numLaps: 60
            ),
            // Another Running
            new Running(
                date: new DateTime(2022, 11, 5),
                durationMinutes: 40.0,
                distanceMiles: 4.5
            )
        };

        Console.WriteLine("--- Fitness Activity Log ---");
        Console.WriteLine("Units: Miles/MPH/Min-per-Mile");
        Console.WriteLine("----------------------------");

        // 2. Iterate through the list and call GetSummary() on each item
        foreach (Activity activity in fitnessLog)
        {
            // Polymorphism ensures the correct overridden calculation methods are used for each type.
            string summary = activity.GetSummary();
            Console.WriteLine(summary);
        }
        
        Console.WriteLine("----------------------------");
    }
}