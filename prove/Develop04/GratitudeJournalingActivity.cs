using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    public class GratitudeJournalingActivity : Activity
    {
        private List<string> _prompts = new List<string>
    {
        "What are three things you are grateful for today?",
        "Who are the people in your life that you appreciate the most? Write about why you are grateful for them.",
        "Think about a recent accomplishment or positive experience. Reflect on the aspects of it that you are grateful for.",
        "Write about a challenge or difficulty you faced and find something positive or a lesson you learned from it.",
        "Reflect on a natural beauty or scene that you find awe-inspiring. Describe it and express your gratitude for it.",
        "Think of a small act of kindness someone has done for you recently. Write about how it made you feel and why you are grateful for it."
    };

        protected override void Start()
        {
            ShowStartingMessage("Gratitude Journaling Activity", "This activity will help you cultivate gratitude by reflecting on things, experiences, and people you are grateful for in your life.");

            Console.WriteLine("Let's begin...");
            Random random = new Random();

            for (int i = 0; i < _duration; i += 5)
            {
                string prompt = _prompts[random.Next(_prompts.Count)];
                Console.WriteLine(prompt);
                Pause(5);
            }

            ShowFinishingMessage("Gratitude Journaling Activity");
        }

        public void StartActivity()
        {
            Start();
            Console.WriteLine();
            Program.ShowMenu();
        }
    }
}
