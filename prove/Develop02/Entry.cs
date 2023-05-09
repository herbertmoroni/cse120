using System.Text.Json.Serialization;

public class Entry
{
    [JsonPropertyName("response")]
    public string Response { get; set; }

    [JsonPropertyName("prompt")]
    public string Prompt { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    public Entry()
    {
        Response = "";
        Prompt = "";
        Date = "";
    }

    public Entry(string response, string prompt)
    {
        Response = response;
        Prompt = prompt;
        Date = DateTime.Now.ToString("yyyy-MM-dd");
    }

    public Entry(string response, string prompt, string date)
    {
        Response = response;
        Prompt = prompt;
        Date = date;
    }

    public override string ToString()
    {
        return Date + " | " + Prompt + " | " + Response;
    }
}
