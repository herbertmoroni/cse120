using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        ShowMenu();
    }

    public static void ShowMenu()
    {
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("-------------------");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Gratitude Journaling Activity");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.StartActivity();
                break;
            case "2":
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.StartActivity();
                break;
            case "3":
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.StartActivity();
                break;
            case "4":
                GratitudeJournalingActivity gratitudeJournalingActivity = new GratitudeJournalingActivity(); //This was added to exceed requirement
                gratitudeJournalingActivity.StartActivity();
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                ShowMenu();
                break;
        }
    }
}

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

public class BreathingActivity : Activity
{
    protected override void Start()
    {
        ShowStartingMessage("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        Console.WriteLine("Let's begin...");
        for (int i = 0; i < 2; i += 2)
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

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
       };

    protected override void Start()
    {
        ShowStartingMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Console.WriteLine("Let's begin...");
        Random random = new Random();

        for (int i = 0; i < _duration; i += 5)
        {
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Pause(2);

            foreach (string question in _questions)
            {
                Console.WriteLine(question);
                Pause(3);
            }
        }

        ShowFinishingMessage("Reflection Activity");
    }

    public void StartActivity()
    {
        Start();
        Console.WriteLine();
        Program.ShowMenu();
    }
}

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