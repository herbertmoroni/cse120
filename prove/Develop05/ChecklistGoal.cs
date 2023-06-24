public class ChecklistGoal : Goal
{
    private int _count;
    private int _completedCount = 0;
    private int _bonus;

    public int Count
    {
        get { return _count; }
        set { _count = value; }
    }

    public int Bonus
    {
        get { return _bonus; }
        set { _bonus = value; }
    }

    public ChecklistGoal(string name, string description, int value, int count, int bonus) : base(name, description, value)
    {
        _count = count;
        _bonus = bonus;
    }

    public override int Complete()
    {
        _completedCount++;
        if (_completedCount == _count)
        {
            _isCompleted = true;
            return _value + _bonus;
        }
        return _value;
    }

    public override string ToString()
    {
        return base.ToString() + $" Completed {_completedCount}/{_count} times.";
    }
}


