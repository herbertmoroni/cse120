public class Journal
{
    private List<Entry> _entries = new List<Entry>();

   
    public void AddEntry()
    {
        string prompt = PromptHandler.GetRandomPrompt();
        Console.WriteLine("Prompt: " + prompt);
        string response = Console.ReadLine();
        Entry entry = new Entry(response, prompt);
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveJournal()
    {
        Console.WriteLine("Enter filename:");
        string filename = Console.ReadLine();

        using (StreamWriter file =  new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
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

        _entries.Clear();

        using (StreamReader file = new StreamReader(filename))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                Entry entry = new Entry(parts[2], parts[1], parts[0]);
                _entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded from " + filename);
    }
}
