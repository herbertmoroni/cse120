public class Entry
{
    private string response;
    private string prompt;
    private string date;

    public Entry(string response, string prompt)
    {
        this.response = response;
        this.prompt = prompt;
        date = DateTime.Now.ToString("yyyy-MM-dd");
    }

    public override string ToString()
    {
        return date + "," + prompt + "," + response;
    }
}