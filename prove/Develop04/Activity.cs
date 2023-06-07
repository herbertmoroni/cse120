using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    public abstract class Activity
    {
        protected int _duration;

        protected abstract void Start();

        protected void ShowStartingMessage(string activityName, string description)
        {
            Console.WriteLine($"Starting {activityName}...");
            Console.WriteLine();
            Console.WriteLine(description);
            Console.WriteLine();
            Console.Write("Enter the duration (in seconds): ");
            _duration = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Preparing to begin...");
            Pause(3);
        }

        protected void ShowFinishingMessage(string activityName)
        {
            Console.WriteLine($"Good job! You have completed the {activityName}.");
            Console.WriteLine();
            Console.WriteLine($"Duration: {_duration} seconds");
            Console.WriteLine();
            Pause(3);
        }

        protected void Pause(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                string spinner = "|/-\\";
                foreach (char c in spinner)
                {
                    Console.Write($"\r{c} Pausing for {i} seconds...");
                    System.Threading.Thread.Sleep(250);
                }
            }
            Console.WriteLine();
        }
    }
}
