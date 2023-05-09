using System.Text.Json;

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
        string filename = "journal.json";

        string json = JsonSerializer.Serialize(_entries);

        using (StreamWriter file = new StreamWriter(filename))
        {
            file.Write(json);
        }

        Console.WriteLine("Journal saved!");
    }

    public void LoadJournal()
    {
        string filename = "journal.json";

        _entries.Clear();

        using (StreamReader file = new StreamReader(filename))
        {
            string json = file.ReadToEnd();
            _entries = JsonSerializer.Deserialize<List<Entry>>(json);
        }

        Console.WriteLine("Journal loaded!");
    }
}
