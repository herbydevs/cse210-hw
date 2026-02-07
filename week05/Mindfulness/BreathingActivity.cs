using System;

namespace Mindfulness
{
    // High-level responsibility: Guide the user through a deep breathing exercise
    public class BreathingActivity : Activity
    {
        // Constructor sets the name and description for the base class
        public BreathingActivity() : base("Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        // The core logic for the breathing exercise
        public override void Run()
        {
            DisplayStartingMessage();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            // Loop continues until the user-specified duration has elapsed
            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                Console.Write("Breathe in...");
                ShowCountDown(4);
                Console.WriteLine();

                Console.Write("Now breathe out...");
                ShowCountDown(6);
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }
}
