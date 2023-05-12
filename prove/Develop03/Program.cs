using Develop03;
using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        library.LoadScripturesFromFiles("scriptures.txt");

        Scripture scripture = library.GetRandomScripture();

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());       

        string input;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");

            input = Console.ReadLine();
            if (input == "quit")
                return;

            scripture.HideRandomWords();
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

        } while (!scripture.AllWordsHidden());


        Console.WriteLine("All words in the scripture are hidden. Press any key to exit.");
        Console.ReadKey();
    }
}
