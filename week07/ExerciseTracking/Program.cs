using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize list with activity types
            List<Activity> activities = new List<Activity>
            {
                new Running("03 Nov 2022", 30, 3.0),
                new Cycling("04 Nov 2022", 45, 12.0),
                new Swimming("05 Nov 2022", 20, 40)
            };

            Console.WriteLine("Exercise Tracking Summary:");
            Console.WriteLine("--------------------------");

            foreach (Activity activity in activities)
            {
                // Polymorphism in action: calling the same method name,
                // but executing different logic based on object type.
                Console.WriteLine(activity.GetSummary());
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
