public class Entry
{
    private string _response;
    private string _prompt;
    private string _date;

    public Entry(string response, string prompt)
    {
        _response = response;
        _prompt = prompt;
        _date = DateTime.Now.ToString("yyyy-MM-dd");
    }

    public Entry(string response, string prompt, string date)
    {
        _response = response;
        _prompt = prompt;
        _date = date;
    }

    public override string ToString()
    {
        return _date + " | " + _prompt + " | " + _response;
    }
}