using System.Text.Json;

public class User
{
    private List<Goal> _goals = new List<Goal>();
    private int _totalScore = 0;

    public string Name { get; set; }

    public List<Goal> Goals
    {
        get { return _goals; }
        set { _goals = value; }
    }

    public int TotalScore
    {
        get { return _totalScore; }
        set { _totalScore = value; }
    }

    public User(string name)
    {
        Name = name;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public int CompleteGoal(int index)
    {
        if (index >= 0 && index < Goals.Count)
        {
            int pointsEarned = Goals[index].Complete();
            TotalScore += pointsEarned;
            return pointsEarned;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid goal index.");
        }
    }

    public void Save(string filename)
    {
        string jsonString = JsonSerializer.Serialize(this);
        File.WriteAllText(filename, jsonString);
    }

    public static User Load(string filename)
    {
        if (File.Exists(filename))
        {
            string jsonString = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<User>(jsonString);
        }

        return null;
    }
}