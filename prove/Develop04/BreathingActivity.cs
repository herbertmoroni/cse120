using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    public class BreathingActivity : Activity
    {
        protected override void Start()
        {
            ShowStartingMessage("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

            Console.WriteLine("Let's begin...");
            for (int i = 0; i < 2; i += 12)
            {
                Console.WriteLine("Breathe in.");
                Pause(4);

                Console.WriteLine("Hold your breath.");
                Pause(4);

                Console.WriteLine("Breathe out.");
                Pause(4);
            }

            ShowFinishingMessage("Breathing Activity");
        }

        public void StartActivity()
        {
            Start();
            Console.WriteLine();
            Program.ShowMenu();
        }
    }
}
