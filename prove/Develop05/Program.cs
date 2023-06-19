using System;

class Program
{
    static void Main(string[] args)
    {
        SimpleGoal test = new SimpleGoal("name1", 1000);
        test.Name = "simple1";

        Goal goal = test;


        QuestProgram program = new QuestProgram();

        program.CreateSimpleGoal("Run a marathon", 1000);
        program.CreateEternalGoal("Read scriptures", 100);
        program.CreateChecklistGoal("Attend the temple", 50, 10, 500);

        program.DisplayGoals();

    }
}

public class Goal
{
    private string _name;
    private bool _completed;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public bool Completed
    {
        get { return _completed; }
        set { _completed = value; }
    }

    public Goal(string name)
    {
        _name = name;
        _completed = false;
    }

    public virtual int GetPoints()
    {
        return 0;
    }

    public virtual bool IsCompleted()
    {
        return _completed;
    }
}

public class SimpleGoal : Goal
{
    private int _points;

    public int Points
    {
        get { return _points; }
        set { _points = value; }
    }

    public SimpleGoal(string name, int points) : base(name)
    {
        _points = points;
    }

    public override int GetPoints()
    {
        return _points;
    }
}

public class EternalGoal : Goal
{
    private int _points;

    public int Points
    {
        get { return _points; }
        set { _points = value; }
    }

    public EternalGoal(string name, int points) : base(name)
    {
        _points = points;
    }

    public override int GetPoints()
    {
        return _points;
    }
}

public class ChecklistGoal : Goal
{
    private int _points;
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public int Points
    {
        get { return _points; }
        set { _points = value; }
    }

    public int TargetCount
    {
        get { return _targetCount; }
        set { _targetCount = value; }
    }

    public int CurrentCount
    {
        get { return _currentCount; }
        set { _currentCount = value; }
    }

    public int BonusPoints
    {
        get { return _bonusPoints; }
        set { _bonusPoints = value; }
    }

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name)
    {
        _points = points;
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override int GetPoints()
    {
        return _points;
    }

    public override bool IsCompleted()
    {
        return _currentCount >= _targetCount;
    }
}

public class QuestProgram
{
    private List<Goal> _goals;
    private int _score;

    public QuestProgram()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void CreateSimpleGoal(string name, int points)
    {
        Goal goal = new SimpleGoal(name, points);
        _goals.Add(goal);
    }

    public void CreateEternalGoal(string name, int points)
    {
        Goal goal = new EternalGoal(name, points);
        _goals.Add(goal);
    }

    public void CreateChecklistGoal(string name, int points, int targetCount, int bonusPoints)
    {
        Goal goal = new ChecklistGoal(name, points, targetCount, bonusPoints);
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        Goal goal = _goals[goalIndex];
        if (!goal.Completed)
        {
            goal.Completed = true;

            if (goal is SimpleGoal simpleGoal)
            {
                _score += simpleGoal.Points;
            }
            else if (goal is EternalGoal eternalGoal)
            {
                _score += eternalGoal.Points;
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                checklistGoal.CurrentCount++;
                _score += checklistGoal.Points;

                if (checklistGoal.CurrentCount >= checklistGoal.TargetCount)
                {
                    _score += checklistGoal.BonusPoints;
                }
            }
        }
    }


    public void DisplayScore()
    {
        Console.WriteLine("Current Score: " + _score);
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string completedStatus = goal.Completed ? "[X]" : "[ ]";
            if (goal is SimpleGoal simpleGoal)
            {
                Console.WriteLine($"{i + 1}. {completedStatus} {goal.Name} - Points: {simpleGoal.Points}");
            }
            else if (goal is EternalGoal eternalGoal)
            {
                Console.WriteLine($"{i + 1}. {completedStatus} {goal.Name} - Points: {eternalGoal.Points}");
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                string progress = $"Completed {checklistGoal.CurrentCount}/{checklistGoal.TargetCount} times";
                Console.WriteLine($"{i + 1}. {completedStatus} {goal.Name} - {progress} - Points: {checklistGoal.Points}");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {completedStatus} {goal.Name}");
            }
        }
    }
}

