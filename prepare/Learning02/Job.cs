public class Job
{
    public string Company { get; set; }
    public string Title { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }

    public string Display()
    {
        return $"{Title} ({Company}) {StartYear}-{EndYear}";
    }
}