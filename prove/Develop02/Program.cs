using System;

class Program
{
    static void Main(string[] args)
    {
       Journal journal = new Journal();

        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Enter a number to choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    journal.AddEntry();
                    break;
                case 2:
                    journal.DisplayEntries();
                    break;
                case 3:
                    journal.SaveJournal();
                    break;
                case 4:
                    journal.LoadJournal();
                    break;
                case 5:
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}


