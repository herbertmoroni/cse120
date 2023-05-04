public class Journal
{
    private List<Entry> entries;
    private List<string> prompts;

    public Journal()
    {
        entries = new List<Entry>();
        prompts = new List<string>();

        prompts.Add("Who was the most interesting person I interacted with today?");
        prompts.Add("What was the best part of my day?");
        prompts.Add("How did I see the hand of the Lord in my life today?");
        prompts.Add("What was the strongest emotion I felt today?");
        prompts.Add("If I had one thing I could do over today, what would it be?");
    }

    public void AddEntry()
    {
        string prompt = prompts[new Random().Next(prompts.Count)];
        Console.WriteLine("Prompt: " + prompt);
        string response = Console.ReadLine();
        Entry entry = new Entry(response, prompt);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveJournal()
    {
        Console.WriteLine("Enter filename:");
        string filename = Console.ReadLine();

        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                file.WriteLine(entry.ToString());
            }
        }

        Console.WriteLine("Journal saved to " + filename);
    }

    public void LoadJournal()
    {
        Console.WriteLine("Enter filename:");
        string filename = Console.ReadLine();

        entries.Clear();

        using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                Entry entry = new Entry(parts[1], parts[0]);
                entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded from " + filename);
    }
}
