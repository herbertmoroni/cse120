using Newtonsoft.Json;

public class User
{
    private Portfolio _portfolio;
    private string _name;

    public User(string name)
    {
        _portfolio = new Portfolio();
        _name = name;
    }

    public Portfolio Portfolio
    {
        get { return _portfolio; }
        set { _portfolio = value; }
    }

    public void SavePortfolio(string fileName)
    {
        string jsonString = JsonConvert.SerializeObject(_portfolio, Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        });
        File.WriteAllText(fileName, jsonString);
    }

    public void OpenPortfolio(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        _portfolio = JsonConvert.DeserializeObject<Portfolio>(jsonString, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        });
    }
}
