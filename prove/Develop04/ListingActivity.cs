using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

        protected override void Start()
        {
            ShowStartingMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

            Console.WriteLine("Let's begin...");
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Pause(5);

            Console.Write("Enter the items (separated by commas): ");
            string input = Console.ReadLine();
            string[] items = input.Split(',');

            Console.WriteLine($"Number of items entered: {items.Length}");

            ShowFinishingMessage("Listing Activity");
        }

        public void StartActivity()
        {
            Start();
            Console.WriteLine();
            Program.ShowMenu();
        }
    }
}
