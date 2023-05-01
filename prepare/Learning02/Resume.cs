public class Resume
{
    public string Name { get; set; }
    public List<Job> Jobs { get; set; }

    public string Display()
    {
        var result = $"{Name}\n";
        foreach (var job in Jobs)
        {
            result += $"{job.Display()}\n";
        }
        return result;
    }
}